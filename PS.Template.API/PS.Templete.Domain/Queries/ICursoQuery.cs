using PS.Templete.Domain.DTOs;
using System.Collections.Generic;

namespace PS.Templete.Domain.Queries
{
    public interface ICursoQuery
    {
        List<ResponseGetAllCursoDto> GetAllCursos(string apellido); 
        ResponseGetCursoById GetById(string cursoId); 
    }
}
