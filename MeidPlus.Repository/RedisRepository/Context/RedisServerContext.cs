using MediPlus.Domain.IRepositories.BaseRepository;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MeidPlus.Repository.RedisRepository.Context
{
  public abstract  class RedisServerContext: RedisUnitOfWork
    {
        protected static ConnectionMultiplexer redisServer = null;
       
        protected override string Connstr => "redisconn";
        public RedisServerContext(IConfiguration configuration) : base(configuration,ref redisServer)
        {

        }
       
    }
}
