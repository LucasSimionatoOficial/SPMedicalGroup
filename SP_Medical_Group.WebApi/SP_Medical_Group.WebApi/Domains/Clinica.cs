using System;
using System.Collections.Generic;

#nullable disable

namespace SP_Medical_Group.WebApi.Domains
{
    public partial class Clinica
    {
        public Clinica()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int IdClinica { get; set; }
        public string Crm { get; set; }
        public decimal? Cpnj { get; set; }
        public string Endereco { get; set; }
        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
