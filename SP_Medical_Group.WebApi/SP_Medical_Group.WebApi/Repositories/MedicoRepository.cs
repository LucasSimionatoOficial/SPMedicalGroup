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
    public class MedicoRepository : IMedicoRepository
    {
        Medical_GroupContext ctx = new Medical_GroupContext();

        /// <summary>
        /// Atualiza medico
        /// </summary>
        /// <param name="medico">medico</param>
        /// <param name="id">id</param>
        public void Atualizar(Medico medico, int id)
        {
            Medico medicoAntigo = ctx.Medicos.Find(id);

            medicoAntigo = medico;

            medicoAntigo.IdMedico = id;

            ctx.Medicos.Add(medicoAntigo);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Cria medico
        /// </summary>
        /// <param name="medico">medico</param>
        public void Criar(Medico medico)
        {
            ctx.Medicos.Add(medico);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta medico
        /// </summary>
        /// <param name="id">id</param>
        public void Deletar(int id)
        {
            Medico medico = ctx.Medicos.Find(id);

            ctx.Medicos.Remove(medico);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista medicos
        /// </summary>
        /// <returns>medicos</returns>
        public List<Medico> Listar()
        {
            return ctx.Medicos.IgnoreAutoIncludes().Include(x => x.IdUsuarioNavigation).Include(x => x.IdEspecialidadeNavigation).ToList();
        }
    }
}
