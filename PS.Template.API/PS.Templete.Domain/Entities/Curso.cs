using System;
using System.Collections.Generic;

namespace PS.Templete.Domain.Entities
{
    public class Curso
    {
        public Guid CursoId { get; set; }
        public string Materia { get; set; }
        public Guid ProfesorId { get; set; }
        public Profesor ProfesorNavigator { get; set; }
        public ICollection<Alumno> AlumnosNavigator { get; set; }
    }
}
