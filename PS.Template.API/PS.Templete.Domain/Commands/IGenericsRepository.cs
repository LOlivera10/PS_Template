using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Templete.Domain.Commands
{
    public interface IGenericsRepository
    {
        void Add<T>(T entity) where T : class;
    }
}
