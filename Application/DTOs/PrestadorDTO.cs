/*Gerado no Gerador de Codigo UCALL
Data: 09/04/2022 23:45:23
*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;



namespace Application.DTOs
{
		public class PrestadorDTO
		{
			public Guid IdPrestador { get; set; }
			public string Nome { get; set; }
			public string Descricao { get; set; }
			public string Nif { get; set; }
			public Guid IdMunicipio { get; set; }
			public string Telefone { get; set; }
			public decimal Latitude { get; set; }
			public decimal Longitude { get; set; }
		}
}
