using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Identity.Entities
{
    [Table("TipoUtilizador", Schema = "Identity")]
    public class TipoUtilizador
	{

        /// <summary>
        /// Atributo chave primária
        /// </summary>
        [Key]
        public int IdTipoUtilizador { get; set; }

        /// <summary>
        /// Descrição tipo utilizador
        /// </summary>
        public string Descricao { get; set; }
    }
}
