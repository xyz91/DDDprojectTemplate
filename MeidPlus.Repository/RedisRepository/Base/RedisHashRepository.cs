using StackExchange.Redis;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace MeidPlus.Repository.RedisRepository
{
    public partial class RedisBaseRepository
    {
        public bool HashExists(string key, string dataKey) => Do(db => db.HashExists(AddPreFixKey(key), dataKey));
        private bool HashSet(string key, string dataKey, RedisValue t) => Do(db => db.HashSet(AddPreFixKey(key), dataKey, t));
        public void HashSet(string key, KeyValuePair<string, string>[] pairs)
        {
            key = AddPreFixKey(key);
            if (pairs.Length > 0)
            {
                HashEntry[] hashes = new HashEntry[pairs.Length];
                for (int i = 0; i < pairs.Length; i++)
                {
                    hashes[i] = new HashEntry(pairs[i].Key, pairs[i].Value);
                }
                Do(db => db.HashSet(key, hashes));
            }
        }
        public bool HashSet(string key, string dataKey, string t) => HashSet(key, dataKey, (RedisValue)t);
        public bool HashSet(string key, string dataKey, int t) => HashSet(key, dataKey, (RedisValue)t);
        public bool HashSet(string key, string dataKey, short t) => HashSet(key, dataKey, (RedisValue)t);
        public bool HashSet(string key, string dataKey, long t) => HashSet(key, dataKey, (RedisValue)t);
        public bool HashSet(string key, string dataKey, float t) => HashSet(key, dataKey, (RedisValue)t);
        public bool HashSet(string key, string dataKey, double t) => HashSet(key, dataKey, (RedisValue)t);
        public long HashDelete(string key, params string[] dataKeys) => Do(db => db.HashDelete(AddPreFixKey(key), dataKeys.Select(a => (RedisValue)a).ToArray()));
        public string HashGet(string key, string dataKey) => Do(db => db.HashGet(AddPreFixKey(key), dataKey));
        public double HashIncrement(string key, string dataKey, double val = 1) => Do(db => db.HashIncrement(AddPreFixKey(key), dataKey, val));
        public double HashDecrement(string key, string dataKey, double val = 1) => Do(db => db.HashDecrement(AddPreFixKey(key), dataKey, val));
        public string[] HashKeys<T>(string key) => Do(db => db.HashKeys(AddPreFixKey(key)));
        public Task<bool> HashExistsAsync(string key, string dataKey) => Do(db => db.HashExistsAsync(AddPreFixKey(key), dataKey));
        private Task<bool> HashSetAsync(string key, string dataKey, RedisValue t) => Do(db => db.HashSetAsync(key, dataKey, t));
        public Task<bool> HashSetAsync(string key, string dataKey, string t) => HashSetAsync(key, dataKey, (RedisValue)t);
        public Task<bool> HashSetAsync(string key, string dataKey, int t) => HashSetAsync(key, dataKey, (RedisValue)t);
        public Task<bool> HashSetAsync(string key, string dataKey, short t) => HashSetAsync(key, dataKey, (RedisValue)t);
        public Task<bool> HashSetAsync(string key, string dataKey, long t) => HashSetAsync(key, dataKey, (RedisValue)t);
        public Task<bool> HashSetAsync(string key, string dataKey, float t) => HashSetAsync(key, dataKey, (RedisValue)t);
        public Task<bool> HashSetAsync(string key, string dataKey, double t) => HashSetAsync(key, dataKey, (RedisValue)t);
        public Task<long> HashDeleteAsync(string key, params string[] dataKeys) => Do(db => db.HashDeleteAsync(AddPreFixKey(key), dataKeys.Select(a => (RedisValue)a).ToArray()));
        public Task<string> HashGeAsync<T>(string key, string dataKey) => Do(db => db.HashGetAsync(AddPreFixKey(key), dataKey));
        public Task<double> HashIncrementAsync(string key, string dataKey, double val = 1) => Do(db => db.HashIncrementAsync(AddPreFixKey(key), dataKey, val));
        public Task<double> HashDecrementAsync(string key, string dataKey, double val = 1) => Do(db => db.HashDecrementAsync(AddPreFixKey(key), dataKey, val));
        public Task<string[]> HashKeysAsync(string key) => Do(db => db.HashKeysAsync(AddPreFixKey(key)));
        public KeyValuePair<string, string>[] HashGetAll(string key) => Do(db => db.HashGetAll(AddPreFixKey(key)));
        public Task<KeyValuePair<string, string>[]> HashGetAllAsync(string key) => Do(db => db.HashGetAllAsync(AddPreFixKey(key)));
        public void HashSetAsync(string key, KeyValuePair<string, string>[] pairs)
        {
            key = AddPreFixKey(key);
            if (pairs.Length > 0)
            {
                HashEntry[] hashes = new HashEntry[pairs.Length];
                for (int i = 0; i < pairs.Length; i++)
                {
                    hashes[i] = new HashEntry(pairs[i].Key, pairs[i].Value);
                }
                Do(db => db.HashSetAsync(key, hashes));
            }
        }
    }
}
