/*Gerado no Gerador de Codigo UCALL
Data: 04/04/2022 00:08:18
*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;



namespace Application.DTOs
{
		public class ManutencaoDTO
		{
			public Guid IdManutencao { get; set; }
			public DateTime DataRegisto { get; set; }
			public DateTime? DataResolucao { get; set; }
			public DateTime? DataDaOcorrencia { get; set; }
			public string Assunto { get; set; }
			public string Descricao { get; set; }
			public string CodManutencao { get; set; }
			public Guid IdEstadoManutencao { get; set; }
			public Guid IdUnidade { get; set; }
			public string IdUser { get; set; }
			public Guid? IdOrigemManutencao { get; set; }
            public Guid? IdPrestador { get; set; }
            public Guid? IdPrioridade { get; set; }
            public Guid? IdSubFamilia { get; set; }
        }
}
