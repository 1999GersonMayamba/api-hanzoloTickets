using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity.Models
{
    [Table("EstadoChat")]
    public class EstadoChat
    {
        /// <summary>
        /// Atributo chave primária
        /// </summary>
        [Key]
        public int IdEstadoChat { get; set; }

        /// <summary>
        /// Descrição tipo utilizador
        /// </summary>
        public string Descricao { get; set; }
    }
}
