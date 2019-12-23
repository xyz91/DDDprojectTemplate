using StackExchange.Redis;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MeidPlus.Repository.RedisRepository
{
    public partial class RedisBaseRepository
    {
        /// <summary>
        /// 删除key
        /// </summary>
        /// <param name="keys">rediskey</param>
        /// <returns>成功删除的个数</returns>
        public long KeyDelete(params string[] keys)
        {
            RedisKey[] newKeys = keys.Select(AddPreFixKey).ToArray();
            return Do(db => db.KeyDelete(newKeys));
        }
        /// <summary>
        /// 异步删除key
        /// </summary>
        /// <param name="keys">rediskey</param>
        /// <returns>成功删除的个数</returns>
        public Task<long> KeyDeleteAsync(params string[] keys)
        {
            RedisKey[] newKeys = keys.Select(AddPreFixKey).ToArray();
            return Do(db => db.KeyDeleteAsync(newKeys));
        }
        /// <summary>
        /// 判断key是否存储
        /// </summary>
        /// <param name="key">redis key</param>
        /// <returns></returns>
        public bool KeyExists(string key)
        {
            key = AddPreFixKey(key);
            return Do(db => db.KeyExists(key));
        }
        /// <summary>
        /// 异步判断key是否存储
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Task<bool> KeyExistsAsync(string key)
        {
            key = AddPreFixKey(key);
            return Do(db => db.KeyExistsAsync(key));
        }
        /// <summary>
        /// 重新命名key
        /// </summary>
        /// <param name="key">就的redis key</param>
        /// <param name="newKey">新的redis key</param>
        /// <returns></returns>
        public bool KeyRename(string key, string newKey)
        {
            key = AddPreFixKey(key);
            return Do(db => db.KeyRename(key, newKey));
        }
        /// <summary>
        /// 重新命名key
        /// </summary>
        /// <param name="key">就的redis key</param>
        /// <param name="newKey">新的redis key</param>
        /// <returns></returns>
        public Task<bool> KeyRenameAsync(string key, string newKey)
        {
            key = AddPreFixKey(key);
            return Do(db => db.KeyRenameAsync(key, newKey));
        }

        /// <summary>
        /// 设置Key的时间
        /// </summary>
        /// <param name="key">redis key</param>
        /// <param name="expiry"></param>
        /// <returns></returns>
        public bool KeyExpire(string key, TimeSpan? expiry = null)
        {
            key = AddPreFixKey(key);
            return Do(db => db.KeyExpire(key, expiry));
        }
        /// <summary>
        /// 设置Key的时间
        /// </summary>
        /// <param name="key">redis key</param>
        /// <param name="expiry"></param>
        /// <returns></returns>
        public Task<bool> KeyExpireAsync(string key, TimeSpan? expiry = null)
        {
            key = AddPreFixKey(key);
            return Do(db => db.KeyExpireAsync(key, expiry));
        }

    }
}
