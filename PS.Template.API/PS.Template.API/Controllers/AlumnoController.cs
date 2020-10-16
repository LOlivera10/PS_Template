using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PS.Template.Application.Services;
using PS.Templete.Domain.DTOs;
using PS.Templete.Domain.Entities;
using System;

namespace PS.Template.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        private readonly IAlumnoService _service;
        public AlumnoController(IAlumnoService service)
        {
            _service = service;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Alumno), StatusCodes.Status201Created)]
        public IActionResult Post(AlumnoDto alumno)
        {
            try
            {
                return new JsonResult(_service.CreateAlumno(alumno)) { StatusCode = 201 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}