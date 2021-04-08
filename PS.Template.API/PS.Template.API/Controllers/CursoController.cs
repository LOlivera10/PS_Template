using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PS.Template.Application.Services;
using PS.Templete.Domain.DTOs;
using System;
using System.Collections.Generic;

namespace PS.Template.API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        private readonly ICursoServices _service;
        public CursoController(ICursoServices service)
        {
            _service = service;
        }

        [HttpPost()]
        [ProducesResponseType(typeof(GenericCreatedResponseDto), StatusCodes.Status201Created)]
        public IActionResult Post(CreateCursoRequestDto curso)
        {
            try
            {
                return new JsonResult(_service.CreateCurso(curso)) { StatusCode = 201 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("{Id}")]
        [ProducesResponseType(typeof(ResponseGetCursoById), StatusCodes.Status200OK)]
        public IActionResult GetCursoById(string Id)
        {
            try
            {
                return new JsonResult(_service.GetById(Id)) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ResponseGetAllCursoDto>), StatusCodes.Status200OK)]
        public IActionResult GetCursos([FromQuery] string apellido)
        {
            try
            {
                return new JsonResult(_service.GetCursos(apellido)) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


    }
}