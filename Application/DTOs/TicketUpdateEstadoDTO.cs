using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
   public class TicketUpdateEstadoDTO
    {
        public Guid IdTicket { get; set; }
        public Guid IdEstado { get; set; }
    }
}
