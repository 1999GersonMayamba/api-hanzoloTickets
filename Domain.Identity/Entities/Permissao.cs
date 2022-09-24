using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Identity.Entities
{
    [Table("Permissoes", Schema = "Identity")]
    public class Permissao
	{

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdPermissao { get; set; }

        public string Nome { get; set; }

        public int IdGrupoPermissao { get; set; }

        [ForeignKey("IdGrupoPermissao")]
        public virtual GrupoPermissao GrupoPermissao { get; set; }

        ////public virtual ICollection<ApplicationUser> Utilizadores { get; set; }
    }
}
