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
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        UsuariosController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Cadastra usuario
        /// </summary>
        /// <param name="usuario">usuario</param>
        /// <returns>StatusCode 201 - Created</returns>
        [HttpPost]
        [Authorize(Roles = "3")]
        public IActionResult Post(Usuario usuario)
        {
            _usuarioRepository.Cadastrar(usuario);

            return StatusCode(201);
        }
    }
}
