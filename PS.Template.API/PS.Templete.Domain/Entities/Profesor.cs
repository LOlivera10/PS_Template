using System;
using System.Collections.Generic;

namespace PS.Templete.Domain.Entities
{
    public class Profesor
    {
        public Guid ProfesorId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public ICollection<Curso> CursosNavigator { get; set; }
    }
}
