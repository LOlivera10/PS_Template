﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PS.Template.AccessData;

namespace PS.Template.AccessData.Migrations
{
    [DbContext(typeof(TemplateDbContext))]
    [Migration("20200501214035_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PS.Templete.Domain.Entities.Alumno", b =>
                {
                    b.Property<Guid>("AlumnoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CursoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Legajo")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AlumnoId");

                    b.HasIndex("CursoId");

                    b.ToTable("Alumnos");
                });

            modelBuilder.Entity("PS.Templete.Domain.Entities.Curso", b =>
                {
                    b.Property<Guid>("CursoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Materia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ProfesorId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CursoId");

                    b.HasIndex("ProfesorId");

                    b.ToTable("Cursos");
                });

            modelBuilder.Entity("PS.Templete.Domain.Entities.Profesor", b =>
                {
                    b.Property<Guid>("ProfesorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProfesorId");

                    b.ToTable("Profesores");
                });

            modelBuilder.Entity("PS.Templete.Domain.Entities.Alumno", b =>
                {
                    b.HasOne("PS.Templete.Domain.Entities.Curso", "CursoNavigator")
                        .WithMany("AlumnosNavigator")
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PS.Templete.Domain.Entities.Curso", b =>
                {
                    b.HasOne("PS.Templete.Domain.Entities.Profesor", "ProfesorNavigator")
                        .WithMany("CursosNavigator")
                        .HasForeignKey("ProfesorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
