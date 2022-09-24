/*Gerado no Gerador de Codigo UCALL
Data: 20/03/2022 22:54:25
*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;



namespace Application.DTOs
{
		public class ExameDTO
		{
			public Guid IdExame { get; set; }
			public string Descricao { get; set; }
			public Guid IdTipoExame { get; set; }
			public Guid IdCategoriaExame { get; set; }
		}
}
