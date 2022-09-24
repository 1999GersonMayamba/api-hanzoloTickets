using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities
{
  public  class TipoDominio
    {
        [Key]
        public Guid IdTipoDominio { get; set; }
        public string Descricao { get; set; }
    }
}
