using PS.Templete.Domain.DTOs;

namespace PS.Templete.Domain.Commands
{
    public interface IGenericsRepository
    {
        void Add<T>(T entity) where T : class;
        ResponseGetCursoById GetByIdCurso(string id);
    }
}
