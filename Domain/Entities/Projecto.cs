using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace Domain.Entities
{
   public class Projecto
    {
        [Key]
        public Guid IdProjecto { get; set; }
        public string Descricao { get; set; }
        public string Cod { get; set; }
    }
}
