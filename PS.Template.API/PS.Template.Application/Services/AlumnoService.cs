using Microsoft.Extensions.Configuration;
using PS.Templete.Domain.Commands;
using PS.Templete.Domain.DTOs;
using PS.Templete.Domain.Entities;
using System;

namespace PS.Template.Application.Services
{
    public interface IAlumnoService
    {
        Alumno CreateAlumno(AlumnoDto alumno);
    }
    public class AlumnoService : IAlumnoService
    {
        private readonly IGenericsRepository _repository;
        private readonly IConfiguration _configuration;
        public AlumnoService(IGenericsRepository repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
        }

        public Alumno CreateAlumno(AlumnoDto alumno)
        {
            _configuration.GetSection("URL").Value;
            var entity = new Alumno
            {
                AlumnoId = Guid.NewGuid(),
                Apellido = alumno.Apellido,
                CursoId = Guid.Parse(alumno.CursoId),
                Nombre = alumno.Nombre,
                Legajo = alumno.Legajo
            };
            _repository.Add<Alumno>(entity);
            Console.WriteLine("creando alumno");
            Console.WriteLine("Creation");
            return entity;
        }
    }
}
