using MediPlus.Domain.IRepositories.BaseRepository;
using MediPlus.Domain.IRepositories.Context;
using MeidPlus.Repository.RedisRepository.Context;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MR = MediPlus.Domain.IRepositories.BaseRepository;
namespace MeidPlus.Repository.RedisRepository
{
    public abstract partial class RedisBaseRepository : IRedisRepository
    {
        public RedisServerContext RedisServer;
        public virtual string prefixKey { get; } = "MediPlus";
        public RedisBaseRepository(IRedisBaseContext context) => RedisServer = context as RedisServerContext;
        private T Do<T>(Func<IDatabase, T> func) => func(RedisServer.Database);
        //private T Do<T>(Func<ISubscriber,T> func) {
        //    return func(RedisServer.Subscriber);
        //}

        private string Do(Func<IDatabase, RedisValue> func)
        {
            RedisValue result = Do<RedisValue>(func);
            if (result.HasValue)
            {
                return result.ToString();
            }
            else
            {
                return null;
            }
        }
        private async Task<string> Do(Func<IDatabase, Task<RedisValue>> func)
        {
            RedisValue result = await Do<Task<RedisValue>>(func);
            if (result.HasValue)
            {
                return result.ToString();
            }
            else
            {
                return null;
            }
        }
        private string[] Do(Func<IDatabase, RedisValue[]> func)
        {

            RedisValue[] result = Do<RedisValue[]>(func);
            return Convert(result);
        }
        private KeyValuePair<string, string> Do(Func<IDatabase, HashEntry> func)
        {
            HashEntry result = Do<HashEntry>(func);
            return KeyValuePair.Create<string, string>(result.Name, result.Value);
        }
        private KeyValuePair<string, string>[] Do(Func<IDatabase, HashEntry[]> func)
        {
            HashEntry[] result = Do<HashEntry[]>(func);
            return Convert(result);
        }
        private async Task<KeyValuePair<string, string>> Do(Func<IDatabase, Task<HashEntry>> func)
        {
            HashEntry result = await Do<Task<HashEntry>>(func);
            return KeyValuePair.Create<string, string>(result.Name, result.Value);
        }
        private async Task<KeyValuePair<string, string>[]> Do(Func<IDatabase, Task<HashEntry[]>> func)
        {
            HashEntry[] result = await Do<Task<HashEntry[]>>(func);
            return Convert(result);
        }
        private async Task<string[]> Do(Func<IDatabase, Task<RedisValue[]>> func)
        {
            RedisValue[] result = await Do<Task<RedisValue[]>>(func);
            return Convert(result);
        }
        private MR.GeoRadiusResult[] Do(Func<IDatabase, StackExchange.Redis.GeoRadiusResult[]> func)
        {
            StackExchange.Redis.GeoRadiusResult[] result = Do<StackExchange.Redis.GeoRadiusResult[]>(func);
            return Convert(result);
        }
        private async Task<MR.GeoRadiusResult[]> Do(Func<IDatabase, Task<StackExchange.Redis.GeoRadiusResult[]>> func)
        {
            StackExchange.Redis.GeoRadiusResult[] result = await Do<Task<StackExchange.Redis.GeoRadiusResult[]>>(func);
            return Convert(result);
        }
        private string[] Convert(RedisValue[] values)
        {
            if (values.Length > 0)
            {
                string[] str = new string[values.Length];
                for (int i = 0; i < values.Length; i++)
                {
                    if (values[i].HasValue)
                    {
                        str[i] = values[i].ToString();
                    }
                    else
                    {
                        str[i] = null;
                    }
                }
                return str;
            }
            return null;
        }
        private KeyValuePair<string, string>[] Convert(HashEntry[] hashes)
        {
            if (hashes.Length > 0)
            {
                KeyValuePair<string, string>[] pairs = new KeyValuePair<string, string>[hashes.Length];
                for (int i = 0; i < hashes.Length; i++)
                {
                    pairs[i] = KeyValuePair.Create<string, string>(hashes[i].Name, hashes[i].Value);
                }
                return pairs;
            }
            return null;
        }
        private MR.GeoRadiusResult[] Convert(StackExchange.Redis.GeoRadiusResult[] result)
        {
            if (result.Length > 0)
            {
                MR.GeoRadiusResult[] results = new MR.GeoRadiusResult[result.Length];
                for (int i = 0; i < result.Length; i++)
                {
                    MR.GeoRadiusResult geo = new MR.GeoRadiusResult()
                    {
                        Distance = result[i].Distance,
                        Hash = result[i].Hash,
                        Member = result[i].Member,
                    };
                    MR.GeoPosition? position = null;
                    if (result[i].Position != null && result[i].Position.HasValue)
                    {
                        position = new MR.GeoPosition()
                        {
                            Longitude = result[i].Position.Value.Longitude,
                            Latitude = result[i].Position.Value.Latitude
                        };
                    }
                    geo.Position = position;
                    results[i] = geo;
                }
                return results;
            }
            return null;
        }
        private void Do(Action<ISubscriber> action) => action(RedisServer.Subscriber);
        private void Do(Action<IDatabase> action) => action(RedisServer.Database);
        private RedisKey AddPreFixKey(string oldKey) => $"{prefixKey}:{oldKey}";



    }
}
