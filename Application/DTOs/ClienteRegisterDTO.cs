using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
   public class ClienteRegisterDTO
    {

		public DateTime DataNascimento { get; set; }
        public string Nome { get; set; }
        public bool? HasDocument { get; set; }
		public string NTelefone { get; set; }
		public string Nif { get; set; }
		public string Pai { get; set; }
		public string Mae { get; set; }
		public string Endereco { get; set; }
		public string Numero { get; set; }
		public string Ndocumento { get; set; }
		public Guid IdUnidade { get; set; }
		public Guid IdGrupoDocumento { get; set; }
		public Guid IdGrupoSexo { get; set; }
        public Guid? IdGrupoCliente { get; set; }
    }
}
