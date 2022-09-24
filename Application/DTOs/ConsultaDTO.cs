/*Gerado no Gerador de Codigo UCALL
Data: 19/03/2022 13:19:51
*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;



namespace Application.DTOs
{
		public class ConsultaDTO
		{
			public Guid IdConsulta { get; set; }
			public DateTime DataConsulta { get; set; }
			public string NConsulta { get; set; }
			public string Hora { get; set; }
			public string NumeroApolice { get; set; }
			public string NumeroSeguro { get; set; }
			public string IdMedico { get; set; }
			public string BreveHistorial { get; set; }
			public string MotivoConsulta { get; set; }
			public string AntecedentesFamiliares { get; set; }
			public string AntecedentesPessoais { get; set; }
			public decimal Temperatura { get; set; }
			public decimal Peso { get; set; }
			public decimal Altura { get; set; }
			public string MedicamentosIngeridos { get; set; }
			public string Sintomas { get; set; }
			public Guid IdEstadoConsulta { get; set; }
			public Guid IdCliente { get; set; }
			public Guid IdUnidade { get; set; }
			public Guid? IdSeguro { get; set; }
		}
}
