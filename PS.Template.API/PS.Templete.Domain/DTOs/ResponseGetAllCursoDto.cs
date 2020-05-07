using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Templete.Domain.DTOs
{
    public class ResponseGetAllCursoDto
    {
        public Guid CursoId { get; set; }
        public string Materia { get; set; }
        public Guid ProfesorId { get; set; }
        public string ProfesorNombre { get; set; }
        public string ProfesorApellido { get; set; }
    }

}
