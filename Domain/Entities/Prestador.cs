using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
   public class Prestador
    {
        [Key]
        public Guid IdPrestador { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Nif { get; set; }
        public Guid IdMunicipio { get; set; }
        [ForeignKey("IdMunicipio")]
        public virtual Municipio Municipio { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}
