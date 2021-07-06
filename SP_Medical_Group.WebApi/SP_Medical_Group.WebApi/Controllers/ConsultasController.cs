using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SP_Medical_Group.WebApi.Domains;
using SP_Medical_Group.WebApi.Interfaces;
using SP_Medical_Group.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace SP_Medical_Group.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultasController : ControllerBase
    {
        private IConsultumRepository _consultumRepository { get; set; }

        public ConsultasController()
        {
            _consultumRepository = new ConsultumRepository();
        }

        /// <summary>
        /// cria consulta
        /// </summary>
        /// <param name="consulta">consulta</param>
        /// <returns>StatusCode 201 - Created</returns>
        [HttpPost]
        [Authorize(Roles = "3")]
        public IActionResult Post(Consultum consulta)
        {
            _consultumRepository.Criar(consulta);

            return StatusCode(201);
        }

        /// <summary>
        /// atualiza consulta
        /// </summary>
        /// <param name="id">id da consulta</param>
        /// <param name="consulta">consulta</param>
        /// <returns>StatusCode 200- Ok</returns>
        [HttpPost("{id}")]
        [Authorize(Roles = "3")]
        public IActionResult Update(int id, Consultum consulta)
        {
            _consultumRepository.Atualizar(id, consulta);

            return StatusCode(200);
        }

        /// <summary>
        /// Atualiza descricao da consulta
        /// </summary>
        /// <param name="id">id da consulta</param>
        /// <param name="consulta">consulta</param>
        /// <returns>StatusCode 200 - Ok</returns>
        [HttpPatch("editar/{id}")]
        [Authorize(Roles = "2")]
        public IActionResult UpdateDescricao(int id, Consultum consulta)
        {
            Consultum _consulta = new Consultum();
            _consulta.Descricao = consulta.Descricao;

            _consultumRepository.Atualizar(id, _consulta);

            return StatusCode(200);
        }

        /// <summary>
        /// Lista consultas de um medico logado
        /// </summary>
        /// <returns>StatusCode 200 - Ok consultas</returns>
        [HttpGet("agendadas/")]
        [Authorize(Roles = "2")]
        public IActionResult GetConsultas()
        {
            List<Consultum> Consultas = _consultumRepository.ListarMed(Convert.ToInt32(HttpContext.User.Claims.First(x => x.Type == JwtRegisteredClaimNames.Jti).Value));

            return StatusCode(200, Consultas);
        }
        
        /// <summary>
        /// Lista consultas de um paciente logado
        /// </summary>
        /// <returns>StatusCode 200 - Ok consultas</returns>
        [HttpGet]
        [Authorize(Roles = "1")]
        public IActionResult Get()
        {
            List<Consultum> Consultas = _consultumRepository.ListarPa(Convert.ToInt32(HttpContext.User.Claims.First(x => x.Type == JwtRegisteredClaimNames.Jti).Value));

            return StatusCode(200, Consultas);
        }

        [HttpGet("listaradm/")]
        public IActionResult ListarAdmin()
        {
            List<Consultum> consultas = _consultumRepository.Listar();

            return StatusCode(200, consultas);
        }
    }
}
