using PS.Templete.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Template.AccessData.Commands
{
    public class GenericsRepository : IGenericsRepository
    {
        private readonly TemplateDbContext _context;
        public GenericsRepository (TemplateDbContext dbContext)
        {
            _context = dbContext;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
            _context.SaveChanges();
        }
    }

   
}
