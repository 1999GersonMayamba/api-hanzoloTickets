using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Identity.Entities
{
    [Table("PermissoesUtilizadores", Schema = "Identity")]
    public class PermissaoUtilizador
    {


        [Key]
        public Guid IdPermissaoUtilizador { get; set; }

   
        public int IdPermissao { get; set; }

        [ForeignKey("IdPermissao")]
        public virtual Permissao Permissao { get; set; }


        public string IdUtilizador  { get; set; }

        [ForeignKey("IdUtilizador")]
        public virtual ApplicationUser Utilizador { get; set; }
    }
}
