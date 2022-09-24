using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
   public class ProjectoManutencao
    {
        [Key]
        public Guid IdProjectoManutencao { get; set; }
        public Guid IdManutencao { get; set; }
        [ForeignKey("IdManutencao")]
        public virtual Manutencao Manutencao { get; set; }
        public Guid IdProjecto { get; set; }
        [ForeignKey("IdProjecto")]
        public virtual Projecto Projecto { get; set; }
    }
}
