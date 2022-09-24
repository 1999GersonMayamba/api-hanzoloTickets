using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
   public class Municipio
    {
        [Key]
        public Guid IdMunicipio { get; set; }
        public Guid IdProvincia { get; set; }
        [ForeignKey("IdProvincia")]
        public virtual Provincia Provincia { get; set; }
        public string Descricao { get; set; }
    }
}
