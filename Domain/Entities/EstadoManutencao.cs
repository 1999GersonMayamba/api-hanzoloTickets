using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities
{
   public class EstadoManutencao
    {
        [Key]
        public Guid IdEstadoManutencao { get; set; }
        public string Descricao { get; set; }
    }
}
