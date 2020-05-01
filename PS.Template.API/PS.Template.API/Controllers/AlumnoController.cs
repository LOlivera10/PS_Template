using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PS.Template.Application.Services;
using PS.Templete.Domain.DTOs;
using PS.Templete.Domain.Entities;

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
        public Alumno Post(AlumnoDto alumno)
        {
            return _service.CreateAlumno(alumno);
        }
    }
}