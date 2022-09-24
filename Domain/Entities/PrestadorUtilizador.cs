using Domain.Identity.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
   public class PrestadorUtilizador
    {
        [Key]
        public Guid IdPrestadorUtilizador { get; set; }
        public string IdUser { get; set; }
        [ForeignKey("IdUser")]
        public virtual ApplicationUser ApplicationUser { get; set; }

        public Guid? IdEspecialidadeMedica { get; set; }
        [ForeignKey("IdEspecialidadeMedica")]
        public virtual EspecialidadeMedica EspecialidadeMedica { get; set; }
        public Guid IdPrestador { get; set; }
        [ForeignKey("IdPrestador")]
        public virtual Prestador Prestador { get; set; }
    }
}
