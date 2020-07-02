using System;

namespace PS.Template.Application
{
    public class Util
    {
        public bool ValidarFormatoCursoId(string cursoId)
        {
            return Guid.TryParse(cursoId, out Guid _);
        }
    }
}
