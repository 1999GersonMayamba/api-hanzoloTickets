using Domain.Identity.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
   public class UnidadeUtilizador
    {
        [Key]
        public Guid IdUnidadeUtilizador { get; set; }
        public string IdUser { get; set; }
        [ForeignKey("IdUser")]
        public virtual ApplicationUser ApplicationUser { get; set; }
        public Guid IdUnidade { get; set; }
        [ForeignKey("IdUnidade")]
        public virtual Unidade Unidade { get; set; }
        public Guid? IdEspecialidadeMedica { get; set; }
        [ForeignKey("IdEspecialidadeMedica")]
        public virtual EspecialidadeMedica EspecialidadeMedica { get; set; }
    }
}
