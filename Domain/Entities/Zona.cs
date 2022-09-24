using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities
{
   public class Zona
    {
        [Key]
        public Guid IdZona { get; set; }
        public string Descricao { get; set; }
    }
}
