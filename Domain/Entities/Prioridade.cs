using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities
{
   public class Prioridade
    {
        [Key]
        public Guid IdPrioridade { get; set; }
        public string  Descricao { get; set; }
    }
}
