using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities
{
   public class Provincia
    {
        [Key]
        public Guid IdProvincia { get; set; }
        public string Descricao { get; set; }
    }
}
