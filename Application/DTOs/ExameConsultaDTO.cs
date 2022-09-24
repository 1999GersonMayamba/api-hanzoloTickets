/*Gerado no Gerador de Codigo UCALL
Data: 22/03/2022 12:39:49
*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;



namespace Application.DTOs
{
		public class ExameConsultaDTO
		{
			public Guid IdExameConsulta { get; set; }
			public DateTime DataRegisto { get; set; }
			public Guid IdConsulta { get; set; }
			public Guid IdExame { get; set; }
			public Guid IdPrioridade { get; set; }
			public Guid IdEstadoExame { get; set; }
			public string Descricao { get; set; }
			public decimal ValorPagoMedico { get; set; }
			public decimal ValorPagoTecnicoLaboratotio { get; set; }
			public decimal ValorSuportadoPeloCliente { get; set; }
			public decimal ValorExame { get; set; }
			public string IdUserLab { get; set; }
		}
}
