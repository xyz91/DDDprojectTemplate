using System;
using System.Threading.Tasks;

namespace MeidPlus.Repository.RedisRepository
{
    public partial class RedisBaseRepository
    {
        private static string machine = Environment.MachineName;
        private static TimeSpan locktime = TimeSpan.FromSeconds(30);
        /// <summary>
        /// 加锁
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="time">锁定时间 不传默认30秒</param>
        /// <param name="token">token 不传默认当前机器名</param>
        /// <returns></returns>
        public bool Lock(string key, TimeSpan? time = null, string token = null) => Do(db => db.LockTake(AddPreFixKey(key), token ?? machine, time ?? locktime));
        /// <summary>
        /// 释放锁
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="token">token 要和锁定时的token一致</param>
        /// <returns></returns>
        public bool UnLock(string key, string token = null) => Do(db => db.LockRelease(AddPreFixKey(key), token ?? machine));
        /// <summary>
        /// 加锁
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="time">锁定时间 不传默认30秒</param>
        /// <param name="token">token 不传默认当前机器名</param>
        /// <returns></returns>
        public Task<bool> LockAsync(string key, TimeSpan? time = null, string token = null) => Do(db => db.LockTakeAsync(AddPreFixKey(key), token ?? machine, time ?? locktime));
        /// <summary>
        /// 释放锁
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="token">token 要和锁定时的token一致</param>
        /// <returns></returns>
        public Task<bool> UnLockAsync(string key, string token = null) => Do(db => db.LockReleaseAsync(AddPreFixKey(key), token ?? machine));
        /// <summary>
        /// 查询key的token
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string LockQuery(string key) => Do(db => db.LockQuery(AddPreFixKey(key)));
        /// <summary>
        /// 查询key的token
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Task<string> LockQueryAsync(string key) => Do(db => db.LockQueryAsync(AddPreFixKey(key)));
    }
}
