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
using MediPlus.Domain.IRepositories.Context;
using System.Threading.Tasks;

namespace MeidPlus.Repository.MongoRepository
{
    public abstract class MongoBaseRepository<T,K> : IRepository<T, K>, IMongoRepository<T, K> where T : AggregateRoot<K> 
    {
        private MongoUnitOfWork unitOfWork;
        protected MongoBaseRepository(IMongoBaseContext unitOfWork) {
            this.unitOfWork = unitOfWork as MongoUnitOfWork;

        }
        public IQueryable<T> Entities => Collection.AsQueryable();

        public IMongoCollection<T> Collection => unitOfWork.GetCollection<T>();

        public int Delete(K id)
        {
            var filter = Builders<T>.Filter.Eq(a=>a.Id,id);
           return  Convert.ToInt32(Collection.DeleteOne(filter).DeletedCount);
        }
        public Page<T> Search<P>(int pageIndex, int pageSize, Expression<Func<T, bool>> where = null, Expression<Func<T, P>> orderby = null, bool desc = true)
        {
           
            Page<T> page = new Page<T>() { PageIndex = pageIndex, PageSize = pageSize };
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
        public async Task<Page<T>> SearchAsync<P>(int pageIndex, int pageSize, Expression<Func<T, bool>> where = null, Expression<Func<T, P>> orderby = null, bool desc = true)
        {
            return await Task.Run(() => {
                Page<T> page = new Page<T>() { PageIndex = pageIndex, PageSize = pageSize };
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
        public Page<T> Search(int pageIndex, int pageSize, Expression<Func<T, bool>> where = null)
        {
            return Search<K>(pageIndex, pageSize, where, a => a.Id, true);
        }
        public  Task<Page<T>> SearchAsync(int pageIndex, int pageSize, Expression<Func<T, bool>> where = null)
        {
            return  SearchAsync<K>(pageIndex, pageSize, where, a=>a.Id,true);
        }
        public int Delete(T t) {
           int i =  Delete(t.Id);
            unitOfWork.DoEvent(t);
            return i;
        }
        public T GetById(K id) {
            var filter = Builders<T>.Filter.Eq(a => a.Id, id);
            return Collection.Find(filter).FirstOrDefault();
        }
        public int Insert(T t) {
            Collection.InsertOne(t);
            unitOfWork.DoEvent(t);
            return 1;
        }        
        public int Update(T t) {
            var filter = Builders<T>.Filter.Eq(a => a.Id, t.Id);
            var result = Collection.ReplaceOne(filter, t, new UpdateOptions() { IsUpsert = true });
            if (result.ModifiedCount > 0)
            {
                unitOfWork.DoEvent(t);
            }
            return Convert.ToInt32( result.ModifiedCount);
        }

        public async Task<int> InsertAsync(T t) {
            await  Collection.InsertManyAsync(new[] { t });
            unitOfWork.DoEvent(t);
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
                unitOfWork.DoEvent(t);
            }
            return i;
        }
        public async Task<int> UpdateAsync(T t) {
            var filter = Builders<T>.Filter.Eq(a => a.Id, t.Id);
           var result = await Collection.ReplaceOneAsync(filter, t, new UpdateOptions() { IsUpsert = true});
            if (result.ModifiedCount > 0)
            {
                unitOfWork.DoEvent(t);
            }
            return Convert.ToInt32(result.ModifiedCount);
                }
        public async Task<T> GetGyIdAsync(K id) {
            var filter = Builders<T>.Filter.Eq(a => a.Id, id);
            var t = await Collection.FindAsync<T>(filter);
            return await t.FirstOrDefaultAsync();
        }
    }
}
