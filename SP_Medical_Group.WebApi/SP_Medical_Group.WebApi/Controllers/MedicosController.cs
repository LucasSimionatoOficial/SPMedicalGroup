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
    public class MedicosController : ControllerBase
    {
        IMedicoRepository _medicoRepository { get; set; }

        public MedicosController() {
            _medicoRepository = new MedicoRepository();
        }

        [HttpGet]
        [Authorize(Roles = "3")]
        public IActionResult Get() {
            List<Medico> medico = _medicoRepository.Listar();

            return Ok(medico);
        }
    }
}
