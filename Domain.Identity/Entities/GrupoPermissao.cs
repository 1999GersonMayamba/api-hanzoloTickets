using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Identity.Entities
{
    [Table("GruposPermissoes", Schema = "Identity")]
    public class GrupoPermissao
	{
        public GrupoPermissao()
        {
            Permissoes = new HashSet<Permissao>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdGrupoPermissao { get; set; }

        public string Nome { get; set; }

        //public int IdMenu { get; set; }

        public virtual ICollection<Permissao> Permissoes { get; set; }

        //[ForeignKey("IdMenu")]
       

    }
}
