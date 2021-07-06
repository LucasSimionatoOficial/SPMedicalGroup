using SP_Medical_Group.WebApi.Contexts;
using SP_Medical_Group.WebApi.Domains;
using SP_Medical_Group.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP_Medical_Group.WebApi.Repositories
{
    public class ClinicaRepository : IClinicaRepository
    {
        Medical_GroupContext ctx = new Medical_GroupContext();
        public void Atualizar(int id, Clinica clinica)
        {
            Clinica clinicaAntiga = ctx.Clinicas.Find(id);

            if (clinica.Crm != null)
            {
                clinicaAntiga.Crm = clinica.Crm;
            }
            if (clinica.Cpnj != null)
            {
                clinicaAntiga.Cpnj = clinica.Cpnj;
            }
            if (clinica.Endereco != null)
            {
                clinicaAntiga.Endereco = clinica.Endereco;
            }
            if (clinica.NomeFantasia != null)
            {
                clinicaAntiga.NomeFantasia = clinica.NomeFantasia;
            }
            if (clinica.RazaoSocial != null)
            {
                clinicaAntiga.RazaoSocial = clinica.RazaoSocial;
            }

            ctx.Clinicas.Update(clinicaAntiga);

            ctx.SaveChanges();
        }

        public Clinica BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Criar(Clinica clinica)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Clinica> Listar()
        {
            throw new NotImplementedException();
        }
    }
}
