using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
   public class Unidade
    {
        [Key]
        public Guid IdUnidade { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Nif { get; set; }
        public string Descricao { get; set; }
        public Guid IdComuna { get; set; }
        [ForeignKey("IdComuna")]
        public virtual Comuna Comuna { get; set; }
        public Guid IdDominio { get; set; }
        [ForeignKey("IdDominio")]
        public virtual Dominio Dominio { get; set; }

        public string CodAgencia { get; set; }
        public string Responsavel1 { get; set; }
        public string Telefone1 { get; set; }
        public string Telefone11 { get; set; }
        public string Whatsaap1 { get; set; }
        public string Email1 { get; set; }

        public string Responsavel2 { get; set; }
        public string Telefone2 { get; set; }
        public string Telefone22 { get; set; }
        public string Whatsaap2 { get; set; }
        public string Email2 { get; set; }

        public Guid? IdTipoUnidade { get; set; }
        [ForeignKey("IdTipoUnidade")]
        public virtual TipoUnidade TipoUnidade { get; set; }

        public Guid? IdZona { get; set; }
        [ForeignKey("IdZona")]
        public virtual Zona Zona { get; set; }
        public string Telefone { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}
