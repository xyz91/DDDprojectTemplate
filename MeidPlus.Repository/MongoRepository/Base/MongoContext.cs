using System;
using System.Collections.Generic;
using System.Text;
using MediPlus.Domain.Model;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace MeidPlus.Repository.MongoRepository.Base
{
    public abstract class MongoBaseContext
    {
        protected abstract string DataBaseName { get;  }
        protected abstract string Connstr { get; }
        protected IMongoDatabase Database { get; }
        private static object _lock = new object();
        protected MongoBaseContext(IConfiguration configuration, ref MongoClient client)
        {
            if (client == null)
            {
                lock (_lock) {
                    if (client == null)
                    {
                        client = new MongoClient(configuration.GetConnectionString(Connstr));
                    }
                }
            }
            Database = client.GetDatabase(DataBaseName);
            
        }
        
        public  IMongoCollection<T> GetCollection<T>() =>Database.GetCollection<T>(typeof(T).Name);
    }
}
