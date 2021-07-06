using SP_Medical_Group.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP_Medical_Group.WebApi.Interfaces
{
    interface ITipoUsuarioRepository
    {
        /// <summary>
        /// Cria um tipo de usuario
        /// </summary>
        /// <param name="tipoUsuario">tipo de usuario</param>
        void Criar(TipoUsuario tipoUsuario);

        /// <summary>
        /// Lista tipos de usuarios
        /// </summary>
        /// <returns>lista de tipos de usuario</returns>
        List<TipoUsuario> Listar();

        /// <summary>
        /// Edita usuario
        /// </summary>
        /// <param name="id">id do tipo de usuario</param>
        /// <param name="tipoUsuario">tipo de usuario</param>
        void Editar(int id, TipoUsuario tipoUsuario);

        /// <summary>
        /// Deleta um tipo de usuario
        /// </summary>
        /// <param name="id">id do tipo de usuario</param>
        void Deletar(int id);

        /// <summary>
        /// Busca tipo de usuario pelo id
        /// </summary>
        /// <param name="id">id do tipo de usuario</param>
        /// <returns>tipo de usuario</returns>
        TipoUsuario BuscarPorId(int id);
    }
}
