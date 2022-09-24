using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
   public class ManutencaoPreventivaAddDTO
    {
		public string Assunto { get; set; }
		public string Descricao { get; set; }
		public Guid IdUnidade { get; set; }
		public DateTime? DataDaOcorrencia { get; set; }
		public DateTime? DataManutencao { get; set; }
		public string TicketNumber { get; set; }
		public string IdUser { get; set; }
		public Guid? IdOrigemManutencao { get; set; }
		public Guid? IdPrestador { get; set; }
		public Guid? IdPrioridade { get; set; }
		public Guid? IdSubFamilia { get; set; }
		public ICollection<ProjectoManutencaoPreventivaAddDTO> ProjectoManutencao { get; set; }
		public ICollection<AlocacaoManutencaoAddDTO> AlocacaoManutencao { get; set; }
	}
}
