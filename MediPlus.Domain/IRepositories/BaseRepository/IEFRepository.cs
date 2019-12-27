using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using MediPlus.Domain.Model;

namespace MediPlus.Domain.IRepositories.BaseRepository
{
    /// <summary>
    /// 为了使用不同仓储的特性功能而添加 也可不用，不影响正常功能
    /// 比如下面的ef的显示加载功能
    /// 当然这些功能也能直接定义在具体聚合根对应的irepository中 但那样每个需要使用的这些功能的聚合根都要重复定义
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="K"></typeparam>
    public interface IEFRepository<T,K> where T : AggregateRoot<K>
    {
        /// <summary>
        /// 加载集合属性
        /// </summary>
        /// <typeparam name="P"></typeparam>
        /// <param name="t"></param>
        /// <param name="expression"></param>
        void Load<P>(T t, Expression<Func<T, IEnumerable<P>>> expression, Expression<Func<P, bool>> where = null) where P : class;
        /// <summary>
        /// 加载单个属性
        /// </summary>
        /// <typeparam name="P"></typeparam>
        /// <param name="t"></param>
        /// <param name="expression"></param>
        void Load<P>(T t, Expression<Func<T, P>> expression) where P : class;
    }
}
