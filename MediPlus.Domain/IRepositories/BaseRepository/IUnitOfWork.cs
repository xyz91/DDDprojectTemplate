using MediPlus.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediPlus.Domain.IRepositories.BaseRepository
{
  public  interface IUnitOfWork
    {
        /// <summary>
        /// 新增(不提交)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="K"></typeparam>
        /// <param name="t"></param>
        void RegisAdd<T, K>(T t) where T : AggregateRoot<K>;
        /// <summary>
        /// 更新(不提交)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="K"></typeparam>
        /// <param name="t"></param>
        void RegisUpdate<T, K>(T t) where T : AggregateRoot<K>;
        /// <summary>
        /// 删除(不提交)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="K"></typeparam>
        /// <param name="t"></param>
        void RegisDelete<T, K>(T t) where T : AggregateRoot<K>;
        /// <summary>
        /// 提交变更
        /// </summary>
        /// <returns></returns>
        int Commit();
        /// <summary>
        /// 提交变更(异步)
        /// </summary>
        /// <returns></returns>
        Task<int> CommitAsync();
        /// <summary>
        /// 回滚
        /// </summary>
        void RollBack();
    }
}
