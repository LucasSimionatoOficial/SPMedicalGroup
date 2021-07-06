using SP_Medical_Group.WebApi.Contexts;
using SP_Medical_Group.WebApi.Domains;
using SP_Medical_Group.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP_Medical_Group.WebApi.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        Medical_GroupContext ctx = new Medical_GroupContext();

        /// <summary>
        /// Busca tipo de usuario pelo id
        /// </summary>
        /// <param name="id">id do tipo de usuario</param>
        /// <returns>tipo de usuario</returns>
        public TipoUsuario BuscarPorId(int id)
        {
            return ctx.TipoUsuarios.Find(id);
        }

        /// <summary>
        /// Cria um tipo de usuario
        /// </summary>
        /// <param name="tipoUsuario">tipo de usuario</param>
        public void Criar(TipoUsuario tipoUsuario)
        {
            ctx.TipoUsuarios.Add(tipoUsuario);
        }

        /// <summary>
        /// Deleta um tipo de usuario
        /// </summary>
        /// <param name="id">id do tipo de usuario</param>
        public void Deletar(int id)
        {
            TipoUsuario tipoUsuario = ctx.TipoUsuarios.Find(id);

            ctx.TipoUsuarios.Remove(tipoUsuario);
        }

        /// <summary>
        /// Edita usuario
        /// </summary>
        /// <param name="id">id do tipo de usuario</param>
        /// <param name="tipoUsuario">tipo de usuario</param>
        public void Editar(int id, TipoUsuario tipoUsuario)
        {
            TipoUsuario tipoUsuarioAntigo = ctx.TipoUsuarios.Find(id);
            if (tipoUsuario.Tipo != null)
            {
                tipoUsuarioAntigo.Tipo = tipoUsuario.Tipo;
            }
            ctx.TipoUsuarios.Update(tipoUsuario);
        }

        /// <summary>
        /// Lista tipos de usuarios
        /// </summary>
        /// <returns>lista de tipos de usuario</returns>
        public List<TipoUsuario> Listar()
        {
            return ctx.TipoUsuarios.ToList();
        }
    }
}
