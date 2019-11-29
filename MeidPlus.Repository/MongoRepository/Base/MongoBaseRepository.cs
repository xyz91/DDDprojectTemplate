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
    public abstract class MongoBaseRepository<T,K> : BaseRepository, IRepository<T, K> where T : AggregateRoot<K> 
    {
        private MongoUnitOfWork unitOfWork;
        protected MongoBaseRepository(MongoUnitOfWork unitOfWork) {
            this.unitOfWork = unitOfWork;

        }
        public IQueryable<T> Entities => Collection.AsQueryable();

        public IMongoCollection<T> Collection => unitOfWork.GetCollection<T>();

        public int Delete(K id){
            var filter = Builders<T>.Filter.Eq(a=>a.Id,id);
           return Convert.ToInt32(Collection.DeleteOne(filter).DeletedCount);
        }
        public int Delete(params T[] t) {
            List< FilterDefinition<T>> filter = new List<FilterDefinition<T>>();
            foreach (var item in t)
            {               
                    filter.Add(Builders<T>.Filter.Eq(a => a.Id, item.Id));                               
            }
           var result = Collection.DeleteMany(Builders<T>.Filter.Or(filter)).DeletedCount;
            return Convert.ToInt32(result);
        }
        public T GetById(K id) {
            //var ooo =  Entities.FirstOrDefault();
            
            var filter = Builders<T>.Filter.Eq(a => a.Id, id);

            var oo = Collection.Find(filter);
              var ooo = oo  .First();                         

            return ooo;
        }
        public int Insert(params T[] t) {
            Collection.InsertMany(t);                   
            return 1;
        }

       
        public int Update(T t) {
            List<UpdateDefinition<T>> updates = new List<UpdateDefinition<T>>();
            var filter = Builders<T>.Filter.Eq(a => a.Id, t.Id);

            var result = Collection.ReplaceOne(filter, t, new UpdateOptions() { IsUpsert = true });
            return Convert.ToInt32( result.ModifiedCount);
        }

        [Obsolete("error",true)]
        public int Update(params T[] t) {
            
            return 0;
        }
    }
}
