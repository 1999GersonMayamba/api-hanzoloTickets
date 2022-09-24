/*Gerado no Gerador de Codigo UCALL
Data: 20/03/2022 22:54:28
*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;



namespace Application.DTOs
{
		public class ItemExameDTO
		{
			public Guid IdItemExame { get; set; }
			public string Descricao { get; set; }
			public Guid IdExame { get; set; }
			public Guid IdTipoResultado { get; set; }
			public Guid IdUnidadeHospitalar { get; set; }
			public decimal IntMinLancamentoResultado { get; set; }
			public decimal IntMaxLancamentoResultado { get; set; }
			public decimal IntMinResultado { get; set; }
			public decimal IntMaxResultado { get; set; }
			public decimal ResultadosDaLista { get; set; }
			public int Ordenamento { get; set; }
		}
}
