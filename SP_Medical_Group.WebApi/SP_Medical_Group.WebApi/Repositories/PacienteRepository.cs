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
    public class PacienteRepository : IPacienteRepository
    {
        private Medical_GroupContext ctx = new Medical_GroupContext();

        /// <summary>
        /// Atualiza pacientes
        /// </summary>
        /// <param name="paciente">paciente</param>
        /// <param name="id">id</param>
        public void Atualizar(Paciente paciente, int id)
        {
            Paciente pacienteAntigo = ctx.Pacientes.Find(id);

            pacienteAntigo = paciente;

            pacienteAntigo.IdPaciente = id;

            ctx.Pacientes.Update(pacienteAntigo);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Cria paciente
        /// </summary>
        /// <param name="paciente">paciente</param>
        public void Criar(Paciente paciente)
        {
            ctx.Pacientes.Add(paciente);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta paciente
        /// </summary>
        /// <param name="id">id</param>
        public void Deletar(int id)
        {
            Paciente paciente = ctx.Pacientes.Find(id);

            ctx.Pacientes.Remove(paciente);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista pacientes
        /// </summary>
        /// <returns>pacientes</returns>
        public List<Paciente> Listar()
        {
            return ctx.Pacientes.Include(x => x.IdUsuarioNavigation).ToList();
        }
    }
}
