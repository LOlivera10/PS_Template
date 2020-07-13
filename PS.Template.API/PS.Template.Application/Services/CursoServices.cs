using PS.Templete.Domain.Commands;
using PS.Templete.Domain.DTOs;
using PS.Templete.Domain.Entities;
using PS.Templete.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Template.Application.Services
{
    public class CursoServices : ICursoServices
    {
        private readonly IGenericsRepository _repository;
        private readonly ICursoQuery _query;
        public CursoServices(IGenericsRepository repository, ICursoQuery query)
        {
            _repository = repository;
            _query = query;
        }

        public GenericCreatedResponseDto CreateCurso(CreateCursoRequestDto cursoDto)
        {
            var entity = new Curso
            {
                CursoId = Guid.NewGuid(),
                Materia = cursoDto.Materia,
                ProfesorId = Guid.Parse(cursoDto.ProfesorId)
            };
            _repository.Add(entity);
            return new GenericCreatedResponseDto { Entity = "Curso", Id = entity.CursoId.ToString() };
        }

        public ResponseGetCursoById GetById(string cursoId)
        {

            return _query.GetById(cursoId);
        }

        public List<ResponseGetAllCursoDto> GetCursos(string apellido)
        {

           return  _query.GetAllCursos(apellido);
        }
    }
    public interface ICursoServices
    {
        GenericCreatedResponseDto CreateCurso(CreateCursoRequestDto cursoDto);
        List<ResponseGetAllCursoDto> GetCursos(string apellido);
        ResponseGetCursoById GetById(string cursoId);
    }
}
