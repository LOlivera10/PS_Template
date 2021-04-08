using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PS.Template.AccessData;
using PS.Template.AccessData.Commands;
using PS.Template.AccessData.Queries;
using PS.Template.Application.Services;
using PS.Template.Authentication;
using PS.Templete.Domain.Commands;
using PS.Templete.Domain.Queries;
using SqlKata.Compilers;
using System;
using System.Data;

namespace PS.Template.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            var connectionString = Configuration.GetSection("ConnectionString").Value;
            // EF Core
            services.AddDbContext<TemplateDbContext>(options => options.UseSqlServer(connectionString));

            // SQLKATA
            services.AddTransient<Compiler, SqlServerCompiler>();
            services.AddTransient<IDbConnection>(b =>
            {
                return new SqlConnection(connectionString);
            });


            services.AddTransient<IGenericsRepository, GenericsRepository>();
            services.AddTransient<IAlumnoService, AlumnoService>();
            services.AddTransient<ICursoServices, CursoServices>();
            services.AddTransient<ICursoQuery, CursoQuery>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "PS_Template APIs v1.0",
                    Description = "Test services"
                });
            });

            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });
            services.AddJWTAuthentication(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            var services = app.ApplicationServices.CreateScope();
            try
            {
            services.ServiceProvider.GetRequiredService<TemplateDbContext>().Database.Migrate();
            }
            catch (Exception)
            {
                Console.WriteLine("ErrorMigration");
            }
            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("../swagger/v1/swagger.json", "MyAPI V1");
            });
            app.UseRouting();
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
