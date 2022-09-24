using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    public class NotaUtilizador : AuditableBaseEntity
    {

        //tem que ver este relacionamento
        public string IdUtilizador { get; set; }

        public DateTime DataCriacao { get; set; }

        public string Descricao { get; set; }

        //public Guid IdAnexo { get; set; }

        //[ForeignKey("IdAnexo")]
        //public Anexo Anexo { get; set; }

    }
}
