using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities
{
   public class TipoUnidade
    {
        [Key]
        public Guid IdTipoUnidade { get; set; }
        public string Descricao { get; set; }
    }
}
