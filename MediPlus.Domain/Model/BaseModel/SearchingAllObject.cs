using System;
using System.Collections.Generic;
using System.Text;

namespace MediPlus.Domain.Model
{
    /// <summary>
    /// 搜索数据全集
    /// </summary>
    public class SearchingAllObject<T>
    {
        /// <summary>
        /// 数据集合
        /// </summary>
        public ICollection<T> List { get; set; }
        /// <summary>
        /// 数据总量
        /// </summary>
        public int DataCount { get; set; }
    }
}
