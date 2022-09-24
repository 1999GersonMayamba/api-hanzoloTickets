using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Wrappers
{
    public class PagedResponse<T> : Response<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPage { get; set; }
        public int TotalItems { get; set; }
        public int NextPage { get; set; }
        public int PreviusPage { get; set; }

        public int TotalCurrentDataPage { get; set; }


        public PagedResponse(T data, int pageNumber, int pageSize,  int totalPage, int totalItems, int  totalCurrentDataPage)
        {
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            //this.PreviusPage = previuspage;
            //this.NextPage = nextPage;
            this.Data = data;
            this.TotalPage = totalPage;
            this.Message = null;
            this.Succeeded = true;
            this.Errors = null;
            this.TotalItems = totalItems;
            this.TotalCurrentDataPage = totalCurrentDataPage;
        }
    }
}
