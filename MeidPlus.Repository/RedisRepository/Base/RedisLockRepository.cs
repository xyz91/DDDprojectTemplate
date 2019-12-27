using System;
using System.Threading.Tasks;

namespace MeidPlus.Repository.RedisRepository
{
    public partial class RedisBaseRepository
    {
        private static string machine = Environment.MachineName;
        public bool Lock(string key, int expirySeconds = 30, string token = null) => Do(db => db.LockTake(AddPreFixKey(key), token ?? machine, TimeSpan.FromSeconds(expirySeconds)));
        public bool UnLock(string key, string token = null) => Do(db => db.LockRelease(AddPreFixKey(key), token ?? machine));
        public Task<bool> LockAsync(string key, int expirySeconds = 30, string token = null) => Do(db => db.LockTakeAsync(AddPreFixKey(key), token ?? machine, TimeSpan.FromSeconds(expirySeconds)));
        public Task<bool> UnLockAsync(string key, string token = null) => Do(db => db.LockReleaseAsync(AddPreFixKey(key), token ?? machine));
        public string LockQuery(string key) => Do(db => db.LockQuery(AddPreFixKey(key)));
        public Task<string> LockQueryAsync(string key) => Do(db => db.LockQueryAsync(AddPreFixKey(key)));
    }
}
