/*Gerado no Gerador de Codigo UCALL
Data: 10/03/2022 23:50:53
*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;



namespace Application.DTOs
{
		public class UnidadeDTO
		{
			public Guid IdUnidade { get; set; }
			public string Nome { get; set; }
			public string Endereco { get; set; }
			public string Nif { get; set; }
			public string Descricao { get; set; }
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

            public Guid IdComuna { get; set; }
            public Guid IdDominio { get; set; }
			public Guid? IdTipoUnidade { get; set; }
           public Guid? IdZona { get; set; }
    }
}
