using Application.DTOs.Account;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
  public  class ManutencaoPreventivaRequestDTO
    {
        public Guid IdManutencao { get; set; }
        public DateTime DataRegisto { get; set; }
        public DateTime? DataResolucao { get; set; }
        public DateTime? DataDaOcorrencia { get; set; }
        public DateTime? DataManutencao { get; set; }
        public string TicketNumber { get; set; }
        public string DataRegistoConverted { get; set; }
        public string DataResolucaoConverted { get; set; }
        public string DataDaOcorrenciaConverted { get; set; }
        public string DataManutencaoConverted { get; set; }
        public string Assunto { get; set; }
        public string Descricao { get; set; }
        public Guid IdEstadoManutencao { get; set; }
        public string CodManutencao { get; set; }
        public EstadoManutencaoDTO EstadoManutencao { get; set; }
        public Guid IdUnidade { get; set; }
        public UnidadeDTO Unidade { get; set; }
        public string IdUser { get; set; }
        public Guid? IdOrigemManutencao { get; set; }
        public Guid? IdPrestador { get; set; }
        public OrigemManutencaoDTO OrigemManutencao { get; set; }
        public UserResponseDTO User { get; set; }
        public PrestadorDTO Prestador { get; set; }
        public PrioridadeDTO Prioridade { get; set; }
        public SubFamiliaRequestDTO SubFamilia { get; set; }
        public List<ProjectoManutencaoRequestDTO> ProjectoManutencao { get; set; }
        public List<AlocacaoManutencaoRequestDTO> AlocacaoManutencao { get; set; }
    }
}
