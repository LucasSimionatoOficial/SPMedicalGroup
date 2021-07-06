using SP_Medical_Group.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP_Medical_Group.WebApi.Interfaces
{
    interface IMedicoRepository
    {
        /// <summary>
        /// Cria medico
        /// </summary>
        /// <param name="medico">medico</param>
        void Criar(Medico medico);

        /// <summary>
        /// Lista medicos
        /// </summary>
        /// <returns>medicos</returns>
        List<Medico> Listar();

        /// <summary>
        /// Atualiza medico
        /// </summary>
        /// <param name="medico">medico</param>
        /// <param name="id">id</param>
        void Atualizar(Medico medico, int id);

        /// <summary>
        /// Deleta medico
        /// </summary>
        /// <param name="id">id</param>
        void Deletar(int id);
    }
}
