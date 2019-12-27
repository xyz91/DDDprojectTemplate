using MediPlus.Domain.IRepositories.BaseRepository;
using MediPlus.Domain.Model;
using MeidPlus.Repository.EFRepository.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
namespace MeidPlus.Repository.EFRepository
{
    public abstract class EFBaseRepository<T, K> : IRepository<T, K>, IEFRepository<T, K> where T : AggregateRoot<K>
    {
        private EFUnitOfWork efunitOfWork;
        public EFBaseRepository(EFUnitOfWork unitOfWork) => this.efunitOfWork = unitOfWork;
        public  IQueryable<T> Entities => efunitOfWork.Set<T>();

        public IUnitOfWork unitOfWork => this.efunitOfWork;

        public virtual int Delete(K id)
        {
            T t = GetById(id);
            if (t == null)
            {
                return 0;
            }
            return Delete(t);
        }
        public PagingObject<T> Search<P>(int pageIndex, int pageSize, Expression<Func<T, bool>> where = null, Expression<Func<T, P>> orderby = null, bool desc = true)
        {
            PagingObject<T> page = new PagingObject<T>() { PageIndex = pageIndex, PageSize = pageSize };
            where = where ?? (t => true);
            page.DataCount = Entities.Count(where);
            IQueryable<T> query = (Entities as DbSet<T>).Where(where);
            if (orderby != null)
            {
                query = desc ? query.OrderByDescending(orderby) : query.OrderBy(orderby);
            }
            page.List = query.Skip(page.PageSize * (page.PageIndex - 1)).Take(pageSize).ToList();
            return page;
        }
        public async Task<PagingObject<T>> SearchAsync<P>(int pageIndex, int pageSize, Expression<Func<T, bool>> where = null, Expression<Func<T, P>> orderby = null, bool desc = true) => await Task.Run(async () =>
        {
            PagingObject<T> page = new PagingObject<T>() { PageIndex = pageIndex, PageSize = pageSize };
            where = where ?? (t => true);
            page.DataCount = Entities.Count(where);
            IQueryable<T> query = Entities.Where(where);
            if (orderby != null)
            {
                query = desc ? query.OrderByDescending(orderby) : query.OrderBy(orderby);
            }
            page.List = await query.Skip(page.PageSize * (page.PageIndex - 1)).Take(pageSize).ToListAsync();

            return page;
        });
        public PagingObject<T> Search(int pageIndex, int pageSize, Expression<Func<T, bool>> where = null) => Search<K>(pageIndex, pageSize, where, a => a.Id, true);
        public Task<PagingObject<T>> SearchAsync(int pageIndex, int pageSize, Expression<Func<T, bool>> where = null) => SearchAsync<K>(pageIndex, pageSize, where, a => a.Id, true);
        public virtual void Load<P>(T t, Expression<Func<T, IEnumerable<P>>> expression,Expression<Func<P,bool>> where=null) where P : class => efunitOfWork.Entry(t).Collection<P>(expression).Query().Where(where??(a=>true)).Load();
        public virtual void Load<P>(T t, Expression<Func<T, P>> expression) where P : class => efunitOfWork.Entry(t).Reference(expression).Load();

        public virtual int Delete(T t)
        {
            efunitOfWork.Set<T>().Remove(t);
            return unitOfWork.Commit();
        }
        public virtual T GetById(K id) => efunitOfWork.Set<T>().Find(id);
        public virtual int Insert(T t)
        {
            efunitOfWork.Set<T>().AddRange(t);
            return unitOfWork.Commit();
        }
        public virtual int Update(T t)
        {
            efunitOfWork.Set<T>().Update(t);
            return unitOfWork.Commit();
        }

        public async Task<int> InsertAsync(T t)
        {
            await efunitOfWork.Set<T>().AddAsync(t);
            return await unitOfWork.CommitAsync();
        }
        public async Task<int> DeleteAsync(K id)
        {
            T t = await GetGyIdAsync(id);
            if (t == null)
            {
                return 0;
            }
            return await DeleteAsync(t);
        }
        public Task<int> DeleteAsync(T t)
        {
            efunitOfWork.Set<T>().Remove(t);
            return unitOfWork.CommitAsync();
        }
        public Task<int> UpdateAsync(T t)
        {
            efunitOfWork.Set<T>().Update(t);
            return unitOfWork.CommitAsync();
        }
        public Task<T> GetGyIdAsync(K id) => efunitOfWork.Set<T>().FindAsync(id).AsTask();



        /// <summary>
        /// 计数
        /// </summary>
        /// <param name="where">条件</param>
        /// <returns></returns>
        public int Count(Expression<Func<T, bool>> where = null)
        {
            return Entities.Count(where);
        }

        /// <summary>
        /// 计数(异步)
        /// </summary>
        /// <param name="where">条件</param>
        /// <returns></returns>
        public async Task<int> CountAsync(Expression<Func<T, bool>> where = null)
        {
            return await Task.Run(() =>
            {
                return Entities.Count(where);
            });
        }

        /// <summary>
        /// 查询全集
        /// </summary>
        /// <typeparam name="P">属性</typeparam>
        /// <param name="where">条件</param>
        /// <param name="orderby">排序</param>
        /// <param name="desc">排序类型</param>
        /// <param name="isOnlyCount">是否仅计数</param>
        /// <returns></returns>
        public SearchingAllObject<T> SearchAll<P>(Expression<Func<T, bool>> where = null, Expression<Func<T, P>> orderby = null, bool desc = true)
        {
            SearchingAllObject<T> page = new SearchingAllObject<T>() { };
            where = where ?? (t => true);
            page.DataCount = Entities.Count(where);
            IQueryable<T> query = (Entities as DbSet<T>).Where(where);
            if (orderby != null)
            {
                query = desc ? query.OrderByDescending(orderby) : query.OrderBy(orderby);
            }
            page.List = query.ToList();
            return page;
        }

        /// <summary>
        /// 查询全集(异步)
        /// </summary>
        /// <typeparam name="P">属性</typeparam>
        /// <param name="where">条件</param>
        /// <param name="orderby">排序</param>
        /// <param name="desc">排序类型</param>
        /// <returns></returns>
        public async Task<SearchingAllObject<T>> SearchAllAsync<P>(Expression<Func<T, bool>> where = null, Expression<Func<T, P>> orderby = null, bool desc = true)
        {
            return await Task.Run(() =>
            {
                SearchingAllObject<T> page = new SearchingAllObject<T>() { };
                where = where ?? (t => true);
                page.DataCount = Entities.Count(where);
                IQueryable<T> query = Entities.Where(where);
                if (orderby != null)
                {
                    query = desc ? query.OrderByDescending(orderby) : query.OrderBy(orderby);
                }
                page.List = query.ToList();

                return page;
            });
        }
        /// <summary>
        /// 查询 默认id 倒序
        /// </summary>
        /// <param name="where">条件</param>
        /// <returns></returns>
        public SearchingAllObject<T> SearchAll(Expression<Func<T, bool>> where = null) => SearchAll(where, a => a.Id, true);

        /// <summary>
        /// 查询 默认id 倒序(异步)
        /// </summary>
        /// <param name="where">条件</param>
        /// <returns></returns>
        public async Task<SearchingAllObject<T>> SearchAllAsync(Expression<Func<T, bool>> where = null) => await SearchAllAsync(where, a => a.Id, true);
    }
}
