using System;
using System.Collections.Generic;
using System.Text;

namespace MediPlus.DTO
{
  public  class PagingDTO<T>
    {
        private int _pageIndex = 1;
        private int _pageSize = 10;
        public int PageIndex
        {
            get { return _pageIndex; }
            set { _pageIndex = Math.Max(1, value); }
        }
        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = Math.Max(1, value); }
        }
        public List<T> List { get; set; }
        public int DataCount { get; set; }
        public int PageCount => (int)Math.Ceiling((double)DataCount / PageSize);
    }
}
