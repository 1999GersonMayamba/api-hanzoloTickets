using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
   public class ClienteRequestDTO
    {
		public Guid IdCliente { get; set; }
		public DateTime DataRegisto { get; set; }
		public DateTime? DataNascimento { get; set; }
		public string NTelefone { get; set; }
		public string Nome { get; set; }
        public bool? HasDocument { get; set; }
		public string Nif { get; set; }
		public string Pai { get; set; }
		public string Mae { get; set; }
		public string Endereco { get; set; }
		public string Numero { get; set; }
		public string Ndocumento { get; set; }
        public virtual UnidadeDTO Unidade { get; set; }
        public virtual GrupoDocumentoDTO GrupoDocumento { get; set; }
        public virtual GrupoSexoDTO  GrupoSexo{ get; set; }
        public virtual GrupoClienteDTO GrupoCliente { get; set; }
    }
}
