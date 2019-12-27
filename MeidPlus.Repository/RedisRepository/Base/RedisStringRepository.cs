using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeidPlus.Repository.RedisRepository
{
    public partial class RedisBaseRepository
    {
        public bool StringSet(string key, string value, int expirySeconds = 60*3) => Do(db => db.StringSet(AddPreFixKey(key), value, expirySeconds>=0?TimeSpan.FromSeconds(expirySeconds):default(TimeSpan?)));
        public bool StringSet(KeyValuePair<string, string>[] keyValues)
        {
            KeyValuePair<RedisKey, RedisValue>[] newkeyValues =
                keyValues.Select(p => new KeyValuePair<RedisKey, RedisValue>(AddPreFixKey(p.Key), p.Value)).ToArray();
            return Do(db => db.StringSet(newkeyValues));
        }
        public string StringGet(string key) => Do(db => db.StringGet(AddPreFixKey(key)));
        public string[] StringGet(string[] listKey)
        {
            RedisKey[] newKeys = listKey.Select(AddPreFixKey).ToArray();
            return Do(db => db.StringGet(newKeys));
        }
        public double StringIncrement(string key, double val = 1) => Do(db => db.StringIncrement(AddPreFixKey(key), val));
        public double StringDecrement(string key, double val = 1) => Do(db => db.StringDecrement(AddPreFixKey(key), val));
        public Task<bool> StringSetAsync(string key, string value, int expirySeconds = 60 * 3) => Do(db => db.StringSetAsync(AddPreFixKey(key), value, expirySeconds >= 0 ? TimeSpan.FromSeconds(expirySeconds) : default(TimeSpan?)));
        public Task<bool> StringSetAsync(KeyValuePair<string, string>[] keyValues)
        {
            KeyValuePair<RedisKey, RedisValue>[] newkeyValues =
                keyValues.Select(p => new KeyValuePair<RedisKey, RedisValue>(AddPreFixKey(p.Key), p.Value)).ToArray();
            return Do(db => db.StringSetAsync(newkeyValues));
        }
        public Task<string> StringGetAsync(string key) => Do(db => db.StringGetAsync(AddPreFixKey(key)));
        public Task<string[]> StringGetAsync(string[] listKey)
        {
            RedisKey[] newKeys = listKey.Select(AddPreFixKey).ToArray();
            return Do(db => db.StringGetAsync(newKeys));

        }
        public Task<double> StringIncrementAsync(string key, double val = 1) => Do(db => db.StringIncrementAsync(AddPreFixKey(key), val));
        public Task<double> StringDecrementAsync(string key, double val = 1) => Do(db => db.StringDecrementAsync(AddPreFixKey(key), val));
    }
}
