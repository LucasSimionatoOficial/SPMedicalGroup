using System;
using System.Collections.Generic;

#nullable disable

namespace SP_Medical_Group.WebApi.Domains
{
    public partial class Paciente
    {
        public Paciente()
        {
            Consulta = new HashSet<Consultum>();
        }

        public int IdPaciente { get; set; }
        public int? IdUsuario { get; set; }
        public string Descricao { get; set; }
        public int? Situacao { get; set; }
        public DateTime? DataNascimento { get; set; }
        public long? Telefone { get; set; }
        public long? Rg { get; set; }
        public long? Cpf { get; set; }
        public string Endereco { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Consultum> Consulta { get; set; }
    }
}
