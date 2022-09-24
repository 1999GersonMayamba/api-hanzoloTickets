using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
   public class ExameConsultaAddDTO
    {
		public Guid IdConsulta { get; set; }
		public Guid IdExame { get; set; }
		public Guid? IdPrioridade { get; set; }
		public Guid IdEstadoExame { get; set; }
		public string Descricao { get; set; }
		public string IdUserLab { get; set; }
	}
}
