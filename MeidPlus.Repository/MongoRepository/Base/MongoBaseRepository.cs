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

namespace MeidPlus.Repository.MongoRepository
{
    public abstract class MongoBaseRepository<T,K> : IRepository<T, K> where T : AggregateRoot<K> 
    {
        private MongoUnitOfWork unitOfWork;
        protected MongoBaseRepository(MongoUnitOfWork unitOfWork) {
            this.unitOfWork = unitOfWork;

        }
        public IQueryable<T> Entities => Collection.AsQueryable();

        public IMongoCollection<T> Collection => unitOfWork.GetCollection<T>();

        public int Delete(K id)
        {
            var filter = Builders<T>.Filter.Eq(a=>a.Id,id);
           return Convert.ToInt32(Collection.DeleteOne(filter).DeletedCount);
        }
        public IQueryable<T> Search(System.Linq.Expressions.Expression<Func<T,bool>> expression,int pageIndex=1,int pageSize=10) {

          
            return Entities.Where(expression).Skip(pageSize*(pageIndex-1)).Take(pageSize);
        }
        public int Delete(T t) {
            List< FilterDefinition<T>> filter = new List<FilterDefinition<T>>();
            
           var result = Collection.DeleteOne(Builders<T>.Filter.Eq(a=>a.Id,t.Id));
            return Convert.ToInt32(result.DeletedCount);
        }
        public T GetById(K id) {
            var filter = Builders<T>.Filter.Eq(a => a.Id, id);
            return Collection.Find(filter).FirstOrDefault();
        }
        public int Insert(T t) {
            Collection.InsertOne(t);                   
            return 1;
        }
         [Obsolete("Mongodb不提供此方法",true)]
        public void Load<P>(T t, System.Linq.Expressions.Expression<Func<T, IEnumerable<P>>> expression) where P : class => throw new NotImplementedException();
        [Obsolete("Mongodb不提供此方法", true)]
        public void Load<P>(T t, System.Linq.Expressions.Expression<Func<T, P>> expression) where P : class => throw new NotImplementedException();

        public int Update(T t) {
            List<UpdateDefinition<T>> updates = new List<UpdateDefinition<T>>();
            var filter = Builders<T>.Filter.Eq(a => a.Id, t.Id);
            var result = Collection.ReplaceOne(filter, t, new UpdateOptions() { IsUpsert = true });
            return Convert.ToInt32( result.ModifiedCount);
        }

       
    }
}
