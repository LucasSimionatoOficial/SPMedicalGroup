using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SP_Medical_Group.WebApi.Domains;
using SP_Medical_Group.WebApi.Interfaces;
using SP_Medical_Group.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP_Medical_Group.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PacientesController : ControllerBase
    {
        private IPacienteRepository _pacienteRepository { get; set; }

        public PacientesController() 
        {
            _pacienteRepository = new PacienteRepository();
        }

        [HttpGet]
        [Authorize(Roles = "3")]
        public IActionResult Get() 
        {
            List<Paciente> Pacientes = _pacienteRepository.Listar();

            return Ok(Pacientes);
        }
    }
}
