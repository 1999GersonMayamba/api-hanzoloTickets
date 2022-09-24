using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities
{
   public class Familia
    {
        [Key]
        public Guid IdFamilia { get; set; }
        public string Descricao { get; set; }
    }
}
