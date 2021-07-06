using SP_Medical_Group.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP_Medical_Group.WebApi.Interfaces
{
    interface IPacienteRepository
    {
        /// <summary>
        /// Cria paciente
        /// </summary>
        /// <param name="paciente">paciente</param>
        void Criar(Paciente paciente);

        /// <summary>
        /// Lista pacientes
        /// </summary>
        /// <returns>pacientes</returns>
        List<Paciente> Listar();

        /// <summary>
        /// Atualiza pacientes
        /// </summary>
        /// <param name="paciente">paciente</param>
        /// <param name="id">id</param>
        void Atualizar(Paciente paciente, int id);

        /// <summary>
        /// Deleta paciente
        /// </summary>
        /// <param name="id">id</param>
        void Deletar(int id);
    }
}
