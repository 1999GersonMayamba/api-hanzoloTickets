using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
   public class EspecialidadeMedica
    {
        [Key]
        public Guid IdEspecialidadeMedica { get; set; }
        public string Descricao { get; set; }
        public Guid IdUnidade { get; set; }
        [ForeignKey("IdUnidade")]
        public virtual Unidade Unidade { get; set; }

        public Guid IdDepartamento { get; set; }
        [ForeignKey("IdDepartamento")]
        public virtual Departamento Departamento { get; set; }
    }
}
