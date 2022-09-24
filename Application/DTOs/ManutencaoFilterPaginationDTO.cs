using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
  public  class ManutencaoFilterPaginationDTO
    {
        public Guid IdUnidade { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public ManutencaoFilterPaginationDTO()
        {
            this.PageNumber = 1;
            this.PageSize = 10;
        }
        public ManutencaoFilterPaginationDTO(int pageNumber, int pageSize)
        {
            this.PageNumber = pageNumber < 1 ? 1 : pageNumber;
            this.PageSize = pageSize > 10 ? 10 : pageSize;
            this.PageSize = pageSize < 1 ? 10 : pageSize;
        }
    }
}
