using Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
   public class FilterTicketsDTO
    {
        public string UserId { get; set; }
        public string TicketNumber { get; set; }
        public Guid? EstadoId { get; set; }
        public DateTime? MinDate { get; set; }
        public DateTime? MaxDate { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public FilterTicketsDTO()
        {
            this.PageNumber = 1;
            this.PageSize = 10;
        }
        public FilterTicketsDTO(int pageNumber, int pageSize)
        {
            this.PageNumber = pageNumber < 1 ? 1 : pageNumber;
            this.PageSize = pageSize > 10 ? 10 : pageSize;
            this.PageSize = pageSize < 1 ? 10 : pageSize;
        }

    }
}
