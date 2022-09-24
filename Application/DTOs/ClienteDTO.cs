/*Gerado no Gerador de Codigo UCALL
Data: 19/03/2022 13:19:47
*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;



namespace Application.DTOs
{
		public class ClienteDTO
		{
			public Guid IdCliente { get; set; }
			public DateTime DataRegisto { get; set; }
			public DateTime DataNascimento { get; set; }
			public string NTelefone { get; set; }
			public bool? HasDocument { get; set; }
			public string Nome { get; set; }
			public string Nif { get; set; }
			public string Pai { get; set; }
			public string Mae { get; set; }
			public string Endereco { get; set; }
			public string Numero { get; set; }
			public string Ndocumento { get; set; }
			public Guid IdUnidade { get; set; }
			public Guid IdGrupoDocumento { get; set; }
			public Guid IdGrupoSexo { get; set; }
			public Guid IdGrupoCliente { get; set; }
		}
}
