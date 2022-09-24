using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities
{
   public class Departamento
    {
        [Key]
        public Guid IdDepartamento { get; set; }
        public string Descricao { get; set; }
    }
}
