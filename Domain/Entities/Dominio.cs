using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
   public class Dominio
    {
        [Key]
        public Guid IdDominio { get; set; }
        public string Descricao { get; set; }
        public string Url { get; set; }
        public Guid? IdTipoDominio { get; set; }
        [ForeignKey("IdTipoDominio")]
        public virtual TipoDominio TipoDominio { get; set; }
    }
}
