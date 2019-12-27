using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MediPlus.Domain.IRepositories;
using MongoDB.Driver.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using MediPlus.Domain.IRepositories.BaseRepository;
using MediPlus.Domain.Model.BaseModel;
using MeidPlus.Repository.Base;
using MeidPlus.Repository.MongoRepository.Base;
using MediPlus.Domain.Model;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MeidPlus.Repository.MongoRepository
{
    public abstract class MongoBaseRepository<T,K> : IRepository<T, K>, IMongoRepository<T, K> where T : AggregateRoot<K> 
    {
        private MongoUnitOfWork _unitOfWork;
        protected MongoBaseRepository(MongoUnitOfWork unitOfWork) {
            this._unitOfWork = unitOfWork;
        }
        public IQueryable<T> Entities => Collection.AsQueryable();

        protected IMongoCollection<T> Collection => _unitOfWork.GetCollection<T>();

        public IUnitOfWork unitOfWork => this._unitOfWork;

        public int Delete(K id)
        {
            var filter = Builders<T>.Filter.Eq(a=>a.Id,id);
           return  Convert.ToInt32(Collection.DeleteOne(filter).DeletedCount);
        }
        public PagingObject<T> Search<P>(int pageIndex, int pageSize, Expression<Func<T, bool>> where = null, Expression<Func<T, P>> orderby = null, bool desc = true)
        {
           
            PagingObject<T> page = new PagingObject<T>() { PageIndex = pageIndex, PageSize = pageSize };
            where = where ?? (t => true);
            page.DataCount = Entities.Count(where);
            var query = Entities.Where(where);
            if (orderby != null)
            {
                query = desc ? query.OrderByDescending(orderby) : query.OrderBy(orderby);
            }
            page.List = query.Skip(page.PageSize * (page.PageIndex - 1)).Take(pageSize).ToList();
            
            return page;
        }
        public async Task<PagingObject<T>> SearchAsync<P>(int pageIndex, int pageSize, Expression<Func<T, bool>> where = null, Expression<Func<T, P>> orderby = null, bool desc = true)
        {
            return await Task.Run(() => {
                PagingObject<T> page = new PagingObject<T>() { PageIndex = pageIndex, PageSize = pageSize };
                where = where ?? (t => true);
                page.DataCount = Entities.Count(where);
                var query = Entities.Where(where);
                if (orderby != null)
                {
                    query = desc ? query.OrderByDescending(orderby) : query.OrderBy(orderby);
                }
                page.List = query.Skip(page.PageSize * (page.PageIndex - 1)).Take(pageSize).ToList();

                return page;
            });
            
        }
        public PagingObject<T> Search(int pageIndex, int pageSize, Expression<Func<T, bool>> where = null)
        {
            return Search<K>(pageIndex, pageSize, where, a => a.Id, true);
        }
        public  Task<PagingObject<T>> SearchAsync(int pageIndex, int pageSize, Expression<Func<T, bool>> where = null)
        {
            return SearchAsync<K>(pageIndex, pageSize, where, a => a.Id, true);
        }
        public int Delete(T t) {
           int i =  Delete(t.Id);
            if(i> 0)
            _unitOfWork.DoEvent(t);
            return i;
        }
        public T GetById(K id) {
            var filter = Builders<T>.Filter.Eq(a => a.Id, id);
            return Collection.Find(filter).FirstOrDefault();
        }
        public int Insert(T t) {
            Collection.InsertOne(t);
            _unitOfWork.DoEvent(t);
            return 1;
        }        
        public int Update(T t) {
            var filter = Builders<T>.Filter.Eq(a => a.Id, t.Id);
            var result = Collection.ReplaceOne(filter, t, new UpdateOptions() { IsUpsert = true });
            if (result.ModifiedCount > 0)
            {
                _unitOfWork.DoEvent(t);
            }
            return Convert.ToInt32( result.ModifiedCount);
        }

        public async Task<int> InsertAsync(T t) {
            await  Collection.InsertManyAsync(new[] { t });
            _unitOfWork.DoEvent(t);
            return 1; 
        }
        public async Task<int> DeleteAsync(K id) {
            var filter = Builders<T>.Filter.Eq(a => a.Id, id);
           var result = await  Collection.DeleteOneAsync(filter);
            return Convert.ToInt32( result.DeletedCount);
        }
        public async Task<int> DeleteAsync(T t) {
            var i = await DeleteAsync(t.Id);
            if (i > 0)
            {
                _unitOfWork.DoEvent(t);
            }
            return i;
        }
        public async Task<int> UpdateAsync(T t) {
            var filter = Builders<T>.Filter.Eq(a => a.Id, t.Id);
           var result = await Collection.ReplaceOneAsync(filter, t, new UpdateOptions() { IsUpsert = true});
            if (result.ModifiedCount > 0)
            {
                _unitOfWork.DoEvent(t);
            }
            return Convert.ToInt32(result.ModifiedCount);
                }
        public async Task<T> GetGyIdAsync(K id) {
            var filter = Builders<T>.Filter.Eq(a => a.Id, id);
            var t = await Collection.FindAsync<T>(filter);
            return await t.FirstOrDefaultAsync();
        }

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
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">页容量，如PageSize小于0 则获取全部列表</param>
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
            IQueryable<T> query = Entities.Where(where);
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
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">页容量，如PageSize小于0 则获取全部列表</param>
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
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">页容量，如PageSize小于0 则获取全部列表</param>
        /// <param name="where">条件</param>
        /// <returns></returns>
        public SearchingAllObject<T> SearchAll(Expression<Func<T, bool>> where = null) => SearchAll(where, a => a.Id, true);

        /// <summary>
        /// 查询 默认id 倒序(异步)
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">页容量，如PageSize小于0 则获取全部列表</param>
        /// <param name="where">条件</param>
        /// <returns></returns>
        public async Task<SearchingAllObject<T>> SearchAllAsync(Expression<Func<T, bool>> where = null) => await SearchAllAsync(where, a => a.Id, true);
    }
}
