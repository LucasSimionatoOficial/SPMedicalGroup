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
    public class ClinicasController : ControllerBase
    {
        private IClinicaRepository _clinicaRepository { get; set; }

        ClinicasController()
        {
            _clinicaRepository = new ClinicaRepository();
        }


        /// <summary>
        /// Lista clinicas
        /// </summary>
        /// <returns>StatusCode 200 - Ok clinicas</returns>
        [HttpGet]
        [Authorize(Roles = "3")]
        public IActionResult Get()
        {
            try
            {
                List<Clinica> Clinica = _clinicaRepository.Listar();

                return Ok();
            }

            catch (Exception ex)
            {
                return StatusCode(404, ex);
            }
        }

        /// <summary>
        /// Atualiza clinica
        /// </summary>
        /// <param name="id">id da clinica</param>
        /// <param name="clinica">clinica</param>
        /// <returns>StatusCode 200 - ok</returns>
        [HttpPost("{id}")]
        [Authorize(Roles = "3")]
        public IActionResult Update(int id, Clinica clinica)
        {
            _clinicaRepository.Atualizar(id, clinica);

            return StatusCode(200);
        }

        /// <summary>
        /// Cria clinica
        /// </summary>
        /// <param name="clinica">clinica</param>
        /// <returns>StatusCode 201 - Created</returns>
        [HttpPost]
        [Authorize(Roles = "3")]
        public IActionResult Post (Clinica clinica)
        {
            _clinicaRepository.Criar(clinica);

            return StatusCode(201);
        }
    }
}
