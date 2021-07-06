using Microsoft.EntityFrameworkCore;
using SP_Medical_Group.WebApi.Contexts;
using SP_Medical_Group.WebApi.Domains;
using SP_Medical_Group.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP_Medical_Group.WebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        Medical_GroupContext ctx = new Medical_GroupContext();

        /// <summary>
        /// Atualiza Usuario
        /// </summary>
        /// <param name="id">id do usuario</param>
        /// <param name="usuario">usuario</param>
        public void Atualizar(int id, Usuario usuario)
        {
            Usuario usuarioAntigo = ctx.Usuarios.Find(id);

            if (usuario.IdTipoUsuario != null)
            {
                usuarioAntigo.IdTipoUsuario = usuario.IdTipoUsuario;
            }
            if (usuario.Nome != null)
            {
                usuarioAntigo.Nome = usuario.Nome;
            }
            if (usuario.Email != null)
            {
                usuarioAntigo.Email = usuario.Email;
            }
            if (usuario.Senha != null)
            {
                usuarioAntigo.Senha = usuario.Senha;
            }
            if (usuario.IdClinica != null)
            {
                usuarioAntigo.IdClinica = usuario.IdClinica;
            }

            ctx.Usuarios.Update(usuarioAntigo);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca usuario atraves do emaile senha
        /// </summary>
        /// <param name="email">email</param>
        /// <param name="senha">senha</param>
        /// <returns>Usuario</returns>
        public Usuario BuscarEmailSenha(string email, string senha)
        {
            return ctx.Usuarios.FirstOrDefault(x => x.Email == email && x.Senha == senha);
        }

        /// <summary>
        /// Cadastra um novo usuario
        /// </summary>
        /// <param name="usuario">usuario</param>
        public void Cadastrar(Usuario usuario)
        {
            ctx.Usuarios.Add(usuario);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta usuario
        /// </summary>
        /// <param name="id">id do usuario</param>
        public void Deletar(int id)
        {
            Usuario usuario = ctx.Usuarios.Find(id);

            ctx.Usuarios.Remove(usuario);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista usuarios
        /// </summary>
        /// <returns>Lista de usuarios</returns>
        public List<Usuario> Listar()
        {
            return ctx.Usuarios.Include(x => x.IdTipoUsuarioNavigation).Include(x => x.IdClinicaNavigation).Select(x => new Usuario(){
                Nome = x.Nome,
                IdUsuario = x.IdUsuario,
                IdClinicaNavigation = new Clinica() {
                    IdClinica = x.IdClinicaNavigation.IdClinica,
                    NomeFantasia = x.IdClinicaNavigation.NomeFantasia
                }

            }).ToList();
        }
    }
}
