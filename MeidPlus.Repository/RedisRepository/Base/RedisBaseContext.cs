using MediPlus.Domain.IRepositories.BaseRepository;
using MediPlus.Domain.IRepositories.Context;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MeidPlus.Repository.RedisRepository
{
   public abstract class RedisBaseContext
    {
        public IDatabase Database { get; }
        public ISubscriber Subscriber { get; }
        private static object _lock = new object();
        protected abstract string Connstr { get; }
        protected virtual int DbNum { get; } = -1;
     

        public RedisBaseContext(IConfiguration configuration,ref ConnectionMultiplexer redisServer)
        {
            
            if (redisServer == null || !redisServer.IsConnected)
            {
                lock (_lock)
                {
                    if (redisServer == null || !redisServer.IsConnected)
                    {
                        if (redisServer !=null && !redisServer.IsConnected)
                        {
                            redisServer.Close();redisServer.Dispose();
                        }
                        string str = configuration.GetConnectionString(Connstr);
                        redisServer = ConnectionMultiplexer.Connect(str);
                        redisServer.ConnectionFailed += (o, e) => Console.WriteLine(e.Exception.Message);
                        redisServer.ConnectionRestored += (o, e) => Console.WriteLine(e.Exception.Message);
                        redisServer.ErrorMessage += (o, e) => Console.WriteLine(e.Message);
                        redisServer.HashSlotMoved += (o, e) => Console.WriteLine($"newendpoint:{e.NewEndPoint},oldendpoint:{e.OldEndPoint}");
                        redisServer.InternalError += (o, e) => Console.WriteLine(e.Exception.Message);
                    }
                }
            }
            Database = redisServer.GetDatabase(DbNum);
            Subscriber = redisServer.GetSubscriber();
        }

    }
}
