using System;
using System.Collections.Generic;
using System.Text;
using MediPlus.Domain.Model;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace MeidPlus.Repository.MongoRepository.Base
{
    public abstract class MongoContext
    {
        protected abstract string DataBaseName { get;  }
        protected abstract string Connstr { get; }
        private MongoClient Client { get; set; }
        private IMongoDatabase Database => Client.GetDatabase(DataBaseName);
        protected IConfiguration Configuration { get;}
        protected MongoContext(IConfiguration configuration)
        {
            this.Configuration = configuration;
            Client = new MongoClient(Configuration.GetConnectionString(Connstr));   
        }
        
        public  IMongoCollection<T> GetCollection<T>() =>Database.GetCollection<T>(typeof(T).Name);
    }
}
