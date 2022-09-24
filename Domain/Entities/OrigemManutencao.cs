using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities
{
  public class OrigemManutencao
    {
        [Key]
        public Guid IdOrigemManutencao { get; set; }
        public string Descricao { get; set; }
    }
}
