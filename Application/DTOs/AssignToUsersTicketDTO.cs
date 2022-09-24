using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
   public class AssignToUsersTicketDTO
    {
        public Guid IdTicket { get; set; }
        public List<string> Users { get; set; }
    }
}
