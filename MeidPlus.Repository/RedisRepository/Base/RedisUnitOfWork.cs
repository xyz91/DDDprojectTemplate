using MediPlus.Domain.IRepositories.BaseRepository;
using MediPlus.Domain.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MeidPlus.Repository.RedisRepository
{
   public abstract class RedisUnitOfWork:RedisBaseContext, IUnitOfWork
    {
        public RedisUnitOfWork(IConfiguration configuration, ref StackExchange.Redis.ConnectionMultiplexer redisServer):base(configuration,ref redisServer) { }

        public int Commit() => throw new NotImplementedException();
        public Task<int> CommitAsync() => throw new NotImplementedException();
        public void RegisAdd<T, K>(T t) where T : AggregateRoot<K> => throw new NotImplementedException();
        public void RegisDelete<T, K>(T t) where T : AggregateRoot<K> => throw new NotImplementedException();
        public void RegisUpdate<T, K>(T t) where T : AggregateRoot<K> => throw new NotImplementedException();
        public void RollBack() => throw new NotImplementedException();
    }
}
