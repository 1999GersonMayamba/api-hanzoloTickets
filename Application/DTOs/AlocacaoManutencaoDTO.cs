/*Gerado no Gerador de Codigo UCALL
Data: 09/04/2022 23:44:54
*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;



namespace Application.DTOs
{
		public class AlocacaoManutencaoDTO
		{
			public Guid IdAlocacaoManutencao { get; set; }
			public DateTime DataRegisto { get; set; }
			public DateTime DataManutencao { get; set; }
			public Guid IdManutencao { get; set; }
			public string IdUser { get; set; }
		}
}
