using System;
using System.Collections.Generic;
using System.Text;

namespace MediPlus.DTO
{
  public  class PageBase<T,K> where T:EntityDTO<K> 
    {
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public IEnumerable<T> List { get; set; }
        public int Count { get; set; }
    }
}
