using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
   public class UnidadeRequestDTO
    {
		public Guid IdUnidade { get; set; }
		public string Nome { get; set; }
		public string Endereco { get; set; }
		public string Nif { get; set; }
		public string Descricao { get; set; }
		public Guid IdComuna { get; set; }
		public Guid IdDominio { get; set; }

        public string CodAgencia { get; set; }
        public string Responsavel1 { get; set; }
        public string Telefone1 { get; set; }
        public string Telefone11 { get; set; }
        public string Whatsaap1 { get; set; }
        public string Email1 { get; set; }

        public string Responsavel2 { get; set; }
        public string Telefone2 { get; set; }
        public string Telefone22 { get; set; }
        public string Whatsaap2 { get; set; }
        public string Email2 { get; set; }



        public DominioDTO Dominio { get; set; }
        public ComunaRequestDTO Comuna { get; set; }
        public ZonaDTO Zona { get; set; }
        public TipoUnidadeDTO TipoUnidade { get; set; }
    }
}
