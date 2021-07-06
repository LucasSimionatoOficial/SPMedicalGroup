using SP_Medical_Group.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP_Medical_Group.WebApi.Interfaces
{
    interface IClinicaRepository
    {
        /// <summary>
        /// Cria clinica
        /// </summary>
        /// <param name="clinica">clinica</param>
        void Criar(Clinica clinica);

        /// <summary>
        /// Lista clinicas
        /// </summary>
        /// <returns>lista de clinicas</returns>
        List<Clinica> Listar();

        /// <summary>
        /// Atualiza clinica
        /// </summary>
        /// <param name="id">id da clinica</param>
        /// <param name="clinica">clinica</param>
        void Atualizar(int id, Clinica clinica);

        /// <summary>
        /// Deleta clinica
        /// </summary>
        /// <param name="id">id da clinica</param>
        void Deletar(int id);

        /// <summary>
        /// Busca clinica pelo id
        /// </summary>
        /// <param name="id">id da clinica</param>
        /// <returns>clinica</returns>
        Clinica BuscarPorId(int id);
    }
}
