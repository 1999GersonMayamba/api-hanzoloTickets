using Domain.Identity.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
   public class Manutencao
    {
        [Key]
        public Guid IdManutencao { get; set; }
        public DateTime DataRegisto { get; set; }
        public DateTime? DataResolucao { get; set; }
        public DateTime? DataDaOcorrencia { get; set; }
        public DateTime? DataManutencao { get; set; }
        public string TicketNumber { get; set; }
        public string Assunto { get; set; }
        public string CodManutencao { get; set; }
        public string Descricao { get; set; }
        public Guid IdEstadoManutencao { get; set; }
        [ForeignKey("IdEstadoManutencao")]
        public virtual EstadoManutencao EstadoManutencao { get; set; }
        public Guid IdUnidade { get; set; }
        [ForeignKey("IdUnidade")]
        public virtual Unidade Unidade { get; set; }
        public string IdUser { get; set; }
        [ForeignKey("IdUser")]
        public virtual ApplicationUser ApplicationUser { get; set; }
        public Guid? IdOrigemManutencao { get; set; }
        [ForeignKey("IdOrigemManutencao")]
        public virtual OrigemManutencao OrigemManutencao { get; set; }
        public Guid? IdPrestador { get; set; }
        [ForeignKey("IdPrestador")]
        public virtual Prestador Prestador { get; set; }
        public Guid? IdPrioridade { get; set; }
        [ForeignKey("IdPrioridade")]
        public virtual Prioridade Prioridade { get; set; }
        public Guid? IdSubFamilia { get; set; }
        [ForeignKey("IdSubFamilia")]
        public virtual SubFamilia SubFamilia { get; set; }
        public virtual ICollection<ProjectoManutencao> ProjectoManutencao { get; set; }
        public virtual ICollection<AlocacaoManutencao> AlocacaoManutencao { get; set; }
    }
}
