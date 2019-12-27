using StackExchange.Redis;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MeidPlus.Repository.RedisRepository
{
    public partial class RedisBaseRepository
    {
        public long KeyDelete(params string[] keys)
        {
            RedisKey[] newKeys = keys.Select(AddPreFixKey).ToArray();
            return Do(db => db.KeyDelete(newKeys));
        }
        public Task<long> KeyDeleteAsync(params string[] keys)
        {
            RedisKey[] newKeys = keys.Select(AddPreFixKey).ToArray();
            return Do(db => db.KeyDeleteAsync(newKeys));
        }
        public bool KeyExists(string key) => Do(db => db.KeyExists(AddPreFixKey(key)));
        public Task<bool> KeyExistsAsync(string key) => Do(db => db.KeyExistsAsync(AddPreFixKey(key)));
        public bool KeyRename(string key, string newKey) => Do(db => db.KeyRename(AddPreFixKey(key), newKey));
        public Task<bool> KeyRenameAsync(string key, string newKey) => Do(db => db.KeyRenameAsync(AddPreFixKey(key), newKey));
        public bool KeyExpire(string key, int expiredSeconds=60*3 ) => Do(db => db.KeyExpire(AddPreFixKey(key), expiredSeconds>=0?TimeSpan.FromSeconds(expiredSeconds):default(TimeSpan?)));
        public Task<bool> KeyExpireAsync(string key, int expiredSeconds = 60 * 3) => Do(db => db.KeyExpireAsync(AddPreFixKey(key), expiredSeconds >= 0 ? TimeSpan.FromSeconds(expiredSeconds) : default(TimeSpan?)));

    }
}
