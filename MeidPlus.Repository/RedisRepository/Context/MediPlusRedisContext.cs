
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeidPlus.Repository.RedisRepository.Context
{
 
    public class MediPlusRedisContext : RedisServerContext
    {
        protected override int DbNum => -1;
        public MediPlusRedisContext(IConfiguration configuration):base(configuration) {

        }
    }
}
