﻿using System;

namespace PS.Templete.Domain.Entities
{
    public class Alumno
    {
        public Guid AlumnoId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Legajo { get; set; }
        public Guid CursoId { get; set; }
        public Curso CursoNavigator { get; set; }
    }
}
