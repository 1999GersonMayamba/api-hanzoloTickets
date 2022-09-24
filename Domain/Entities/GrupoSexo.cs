using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


/// <summary>
/// Entidade responsavél pelo sexo de utilizadores
/// </summary>
namespace Domain.Entities
{
   public class GrupoSexo
    {
        [Key]
        public Guid IdGrupoSexo { get; set; }
        public string Descricao { get; set; }
    }
}
