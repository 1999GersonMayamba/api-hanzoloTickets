using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
   public class Equipamento
    {
        [Key]
        public Guid IdEquipamento { get; set; }
        public Guid IdSubFamilia { get; set; }
        [ForeignKey("IdSubFamilia")]
        public virtual SubFamilia SubFamilia { get; set; }
        public Guid IdProjecto { get; set; }
        [ForeignKey("IdProjecto")]
        public virtual Projecto Projecto { get; set; }
        public string Descricao { get; set; }
    }
}
