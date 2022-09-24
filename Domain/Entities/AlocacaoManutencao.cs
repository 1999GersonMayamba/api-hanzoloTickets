using Domain.Identity.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
   public class AlocacaoManutencao
    {
        [Key]
        public Guid IdAlocacaoManutencao { get; set; }
        public DateTime DataRegisto { get; set; }
        public DateTime DataManutencao { get; set; }
        public Guid IdManutencao { get; set; }
        [ForeignKey("IdManutencao")]
        public virtual Manutencao Manutencao { get; set; }
        public string IdUser { get; set; }
        [ForeignKey("IdUser")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
