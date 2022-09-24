using Domain.Identity.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
   public  class TicketAtribuicao
    {
        [Key]
        public Guid IdTicketAtribuicao { get; set; }
        public Guid IdTicket { get; set; }
        [ForeignKey("IdTicket")]
        public virtual Manutencao Manutencao { get; set; }
        public string IdUser { get; set; }
        [ForeignKey("IdUser")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
