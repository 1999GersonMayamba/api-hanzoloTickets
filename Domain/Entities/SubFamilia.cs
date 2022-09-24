using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
   public class SubFamilia
    {
        [Key]
        public Guid IdSubFamilia { get; set; }
        public string Decricao { get; set; }
        public Guid IdFamilia { get; set; }
        [ForeignKey("IdFamilia")]
        public virtual Familia Familia { get; set; }
    }
}
