using System;
using System.Collections.Generic;
using System.Text;

namespace MediPlus.Domain.Model
{
    /// <summary>
    /// 分页类
    /// </summary>
    /// <typeparam name="T"></typeparam>
   public class PagingObject<T>
    {

        private int _pageIndex = 1;
        private int _pageSize = 10;
        /// <summary>
        /// 当前页
        /// </summary>
        public int PageIndex {
            get { return Math.Max(Math.Min(_pageIndex,PageCount),1); }
            set { _pageIndex = Math.Max(1, value); }
        }
        /// <summary>
        /// 页容量
        /// </summary>
        public int PageSize {
            get { return _pageSize; }
            set { _pageSize = Math.Max(1, value); }
        } 
        /// <summary>
        /// 数据集合
        /// </summary>
        public ICollection<T> List { get; set; }
        /// <summary>
        /// 数据总量
        /// </summary>
        public int DataCount { get; set; }
        /// <summary>
        /// 总页数
        /// </summary>
        public int PageCount => (int)Math.Ceiling((double)DataCount / PageSize);
    }
}
