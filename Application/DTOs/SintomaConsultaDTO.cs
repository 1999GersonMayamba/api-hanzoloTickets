/*Gerado no Gerador de Codigo UCALL
Data: 23/03/2022 14:53:12
*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;



namespace Application.DTOs
{
		public class SintomaConsultaDTO
		{
			public Guid IdSintomaConsulta { get; set; }
			public DateTime DataRegisto { get; set; }
			public Guid IdConsulta { get; set; }
			public Guid IdSintoma { get; set; }
			public string Descricao { get; set; }
			public string IdTriagem { get; set; }
		}
}
