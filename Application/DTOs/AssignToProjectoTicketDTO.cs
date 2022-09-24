using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
   public class AssignToProjectoTicketDTO
    {
        public Guid IdTicket { get; set; }
        public Guid  IdProjecto { get; set; }
    }
}
