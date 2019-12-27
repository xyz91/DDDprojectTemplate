using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MediPlus.Domain.Event;
using MediPlus.Domain.Model;
using MediPlus.Domain.Model.BaseModel;

namespace MediPlus.Domain.IRepositories.BaseRepository
{
    public interface IRepository<T,K> where T : AggregateRoot<K>
    {
        IUnitOfWork unitOfWork { get; }
        /// <summary>
        /// 实体集合
        /// </summary>
        IQueryable<T> Entities { get; }
        /// <summary>
        /// 立即添加
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        int Insert(T t);
        /// <summary>
        /// 立即添加(异步)
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        Task<int> InsertAsync(T t);
        /// <summary>
        /// 立即删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int Delete(K id);
        /// <summary>
        /// 立即删除(异步)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<int> DeleteAsync(K id);
        /// <summary>
        /// 立即删除
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        int Delete(T t);
        /// <summary>
        /// 立即删除(异步)
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        Task<int> DeleteAsync(T t);
        /// <summary>
        /// 立即更新
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        int Update(T t);
        /// <summary>
        /// 立即更新(异步)
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        Task<int> UpdateAsync(T t);
        /// <summary>
        /// 根据id获取对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetById(K id);
        /// <summary>
        /// 根据id获取对象(异步)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetGyIdAsync(K id);
        /// <summary>
        /// 查询
        /// </summary>
        /// <typeparam name="P">属性</typeparam>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">页容量</param>
        /// <param name="where">条件</param>
        /// <param name="orderby">排序</param>
        /// <param name="desc">排序类型</param>
        /// <returns></returns>
        PagingObject<T> Search<P>(int pageIndex, int pageSize, Expression<Func<T, bool>> where = null, Expression<Func<T, P>> orderby = null, bool desc = true);
        /// <summary>
        /// 查询 默认id 倒序
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">页容量</param>
        /// <param name="where">条件</param>
        /// <returns></returns>
        PagingObject<T> Search(int pageIndex, int pageSize, Expression<Func<T, bool>> where = null);

        /// <summary>
        /// 查询(异步)
        /// </summary>
        /// <typeparam name="P">属性</typeparam>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">页容量</param>
        /// <param name="where">条件</param>
        /// <param name="orderby">排序</param>
        /// <param name="desc">排序类型</param>
        /// <returns></returns>
        Task<PagingObject<T>> SearchAsync<P>(int pageIndex, int pageSize, Expression<Func<T, bool>> where = null, Expression<Func<T, P>> orderby = null, bool desc = true);
        /// <summary>
        /// 查询 默认id 倒序(异步)
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">页容量</param>
        /// <param name="where">条件</param>
        /// <returns></returns>
        Task<PagingObject<T>> SearchAsync(int pageIndex, int pageSize, Expression<Func<T, bool>> where = null);

        /// <summary>
        /// 计数
        /// </summary>
        /// <param name="where">条件</param>
        /// <returns></returns>
        int Count( Expression<Func<T, bool>> where = null);

        /// <summary>
        /// 计数(异步)
        /// </summary>
        /// <param name="where">条件</param>
        /// <returns></returns>
        Task<int> CountAsync(Expression<Func<T, bool>> where = null);

        /// <summary>
        /// 查询全集
        /// </summary>
        /// <typeparam name="P">属性</typeparam>
        /// <param name="where">条件</param>
        /// <param name="orderby">排序</param>
        /// <param name="desc">排序类型</param>
        /// <returns></returns>
        SearchingAllObject<T> SearchAll<P>(Expression<Func<T, bool>> where = null, Expression<Func<T, P>> orderby = null, bool desc = true);
        /// <summary>
        /// 查询 默认id 倒序
        /// </summary>
        /// <param name="where">条件</param>
        /// <returns></returns>
        SearchingAllObject<T> SearchAll( Expression<Func<T, bool>> where = null);

        /// <summary>
        /// 查询全集(异步)
        /// </summary>
        /// <typeparam name="P">属性</typeparam>
        /// <param name="where">条件</param>
        /// <param name="orderby">排序</param>
        /// <param name="desc">排序类型</param>
        /// <returns></returns>
        Task<SearchingAllObject<T>> SearchAllAsync<P>(Expression<Func<T, bool>> where = null, Expression<Func<T, P>> orderby = null, bool desc = true);

        /// <summary>
        /// 查询 默认id 倒序(异步)
        /// </summary>
        /// <param name="where">条件</param>
        /// <returns></returns>
        Task<SearchingAllObject<T>> SearchAllAsync(Expression<Func<T, bool>> where = null);


    }
}
