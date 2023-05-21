using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Interfaces;

namespace Persistence.Repositories
{
    public class PaginatedResult<T>
    {
        public int PageIndex { get; set; }
        //   public int LastPageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
        public IEnumerable<T> Records { get; set; }

        public PaginatedResult(int pageIndex, int pageSize, int count, IEnumerable<T> data)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalRecords = count;
            Records = data;



        }

    }
}