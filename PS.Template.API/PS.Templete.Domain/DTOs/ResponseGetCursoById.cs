using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Templete.Domain.DTOs
{
    public class ResponseGetCursoById
    {
        public Guid CursoId { get; set; }
        public string Materia { get; set; }
        public ResponseGetCursoByIdProfesor Profesor { get; set; }
        public List<ResponseGetCursoByIdAlumno> Alumnos { get; set; }
    }
    public class ResponseGetCursoByIdProfesor
    {
        public Guid ProfesorId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }
    public class ResponseGetCursoByIdAlumno
    {
        public Guid AlumnoId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Legajo { get; set; }
    }
}
