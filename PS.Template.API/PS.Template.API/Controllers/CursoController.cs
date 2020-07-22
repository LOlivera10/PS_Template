using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PS.Template.Application.Services;
using PS.Templete.Domain.DTOs;
using PS.Templete.Domain.Queries;

namespace PS.Template.API.Controllers
{ 
    [Authorize()]
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
        public IActionResult Post(CreateCursoRequestDto curso)
        {
            try
            {
                return new JsonResult(_service.CreateCurso(curso)) { StatusCode = 201 };
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("{Id?}")]
        public IActionResult GetCursoById(string Id, [FromQuery] string apellido)
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