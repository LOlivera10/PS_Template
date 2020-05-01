using Microsoft.EntityFrameworkCore;
using PS.Templete.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Template.AccessData
{
    public class TemplateDbContext : DbContext
    {
        public TemplateDbContext(DbContextOptions<TemplateDbContext> options)
            : base(options)
        {
        }

        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Profesor> Profesores { get; set; }
    }
}
