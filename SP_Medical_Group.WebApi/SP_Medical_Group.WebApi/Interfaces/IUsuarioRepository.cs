using SP_Medical_Group.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP_Medical_Group.WebApi.Interfaces
{
    interface IUsuarioRepository
    {
        /// <summary>
        /// Busca usuario atraves do emaile senha
        /// </summary>
        /// <param name="email">email</param>
        /// <param name="senha">senha</param>
        /// <returns>Usuario</returns>
        Usuario BuscarEmailSenha(string email, string senha);

        /// <summary>
        /// Cadastra um novo usuario
        /// </summary>
        /// <param name="usuario">usuario</param>
        void Cadastrar(Usuario usuario);

        /// <summary>
        /// Lista usuarios
        /// </summary>
        /// <returns>Lista de usuarios</returns>
        List<Usuario> Listar();

        /// <summary>
        /// Atualiza Usuario
        /// </summary>
        /// <param name="id">id do usuario</param>
        /// <param name="usuario">usuario</param>
        void Atualizar(int id,Usuario usuario);

        /// <summary>
        /// Deleta usuario
        /// </summary>
        /// <param name="id">id do usuario</param>
        void Deletar(int id);
    }
}
