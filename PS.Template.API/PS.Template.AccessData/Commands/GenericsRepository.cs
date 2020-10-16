using PS.Templete.Domain.Commands;
using PS.Templete.Domain.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace PS.Template.AccessData.Commands
{
    public class GenericsRepository : IGenericsRepository
    {
        private readonly TemplateDbContext _context;
        public GenericsRepository(TemplateDbContext dbContext)
        {
            _context = dbContext;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public ResponseGetCursoById GetByIdCurso(string id)
        {
            var lista = new List<ResponseGetCursoById>() { new ResponseGetCursoById() };
            var lista2 = new List<ResponseGetCursoById>() { new ResponseGetCursoById() };

            lista.ForEach(x => { lista2.Add(x); });

            return _context.Cursos
                .Select(x => new ResponseGetCursoById
                {
                    CursoId = x.CursoId
                })
                .FirstOrDefault();

        }
    }


}
