using System;
using System.Collections.Generic;
using System.Text;

namespace MediPlus.Domain.Model.BaseModel
{
   public class PageModel<T>
    {

        private int _pageIndex = 1;
        private int _pageSize = 10;
        public int PageIndex {
            get { return Math.Max(Math.Min(_pageIndex,PageCount),1); }
            set { _pageIndex = Math.Max(1, value); }
        }
        public int PageSize {
            get { return _pageSize; }
            set { _pageSize = Math.Max(1, value); }
        } 
        public ICollection<T> List { get; set; }
        public int DataCount { get; set; }
        public int PageCount => (int)Math.Ceiling((double)DataCount / PageSize);
    }
}
