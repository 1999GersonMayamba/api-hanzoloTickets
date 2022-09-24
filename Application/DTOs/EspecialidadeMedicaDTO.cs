/*Gerado no Gerador de Codigo UCALL
Data: 20/03/2022 13:41:59
*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;



namespace Application.DTOs
{
		public class EspecialidadeMedicaDTO
		{
			public Guid IdEspecialidadeMedica { get; set; }
			public string Descricao { get; set; }
			public Guid IdUnidade { get; set; }
			public Guid IdDepartamento { get; set; }
		}
}
