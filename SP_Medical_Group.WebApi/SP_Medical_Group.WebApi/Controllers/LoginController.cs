using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SP_Medical_Group.WebApi.Domains;
using SP_Medical_Group.WebApi.Interfaces;
using SP_Medical_Group.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SP_Medical_Group.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Faz login
        /// </summary>
        /// <param name="usuario">usuario</param>
        /// <returns>StatusCode 200 - Ok jwt</returns>
        [HttpPost]
        public IActionResult Login(Usuario usuario)
        {
            Usuario usuarioLogado = _usuarioRepository.BuscarEmailSenha(usuario.Email, usuario.Senha);

            if (usuarioLogado == null)
            {
                return StatusCode(400, "email ou senha incorretos");
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, usuarioLogado.Email),
                new Claim(JwtRegisteredClaimNames.Jti, usuarioLogado.IdUsuario.ToString()),
                new Claim(ClaimTypes.Role, usuarioLogado.IdTipoUsuario.ToString()),
                new Claim("role", usuarioLogado.IdTipoUsuario.ToString())
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("SP_Medical_group"));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "Issuer",
                audience: "Audience",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
                );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }
    }
}
