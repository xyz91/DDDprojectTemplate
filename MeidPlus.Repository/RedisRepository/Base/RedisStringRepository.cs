using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeidPlus.Repository.RedisRepository
{
    public partial class RedisBaseRepository
    {

        /// <summary>
        /// 保存单个key value
        /// </summary>
        /// <param name="key">Redis Key</param>
        /// <param name="value">保存的值</param>
        /// <param name="expiry">过期时间</param>
        /// <returns></returns>
        public bool StringSet(string key, string value, TimeSpan? expiry = null)
        {
            key = AddPreFixKey(key);
            return Do(db => db.StringSet(key, value, expiry));
        }

        /// <summary>
        /// 保存多个key value
        /// </summary>
        /// <param name="keyValues">键值对</param>
        /// <returns></returns>
        public bool StringSet(KeyValuePair<string, string>[] keyValues)
        {
            KeyValuePair<RedisKey, RedisValue>[] newkeyValues =
                keyValues.Select(p => new KeyValuePair<RedisKey, RedisValue>(AddPreFixKey(p.Key), p.Value)).ToArray();
            return Do(db => db.StringSet(newkeyValues));
        }


        /// <summary>
        /// 获取单个key的值
        /// </summary>
        /// <param name="key">Redis Key</param>
        /// <returns></returns>
        public string StringGet(string key)
        {
            key = AddPreFixKey(key);
            return Do(db => db.StringGet(key));
        }

        /// <summary>
        /// 获取多个Key
        /// </summary>
        /// <param name="listKey">Redis Key集合</param>
        /// <returns></returns>
        public string[] StringGet(string[] listKey)
        {
            RedisKey[] newKeys = listKey.Select(AddPreFixKey).ToArray();
            return Do(db => db.StringGet(newKeys));
        }

        /// <summary>
        /// 为数字增长val
        /// </summary>
        /// <param name="key"></param>
        /// <param name="val">可以为负</param>
        /// <returns>增长后的值</returns>
        public double StringIncrement(string key, double val = 1)
        {
            key = AddPreFixKey(key);
            return Do(db => db.StringIncrement(key, val));
        }

        /// <summary>
        /// 为数字减少val
        /// </summary>
        /// <param name="key"></param>
        /// <param name="val">可以为负</param>
        /// <returns>减少后的值</returns>
        public double StringDecrement(string key, double val = 1)
        {
            key = AddPreFixKey(key);
            return Do(db => db.StringDecrement(key, val));
        }



        /// <summary>
        /// 保存单个key value
        /// </summary>
        /// <param name="key">Redis Key</param>
        /// <param name="value">保存的值</param>
        /// <param name="expiry">过期时间</param>
        /// <returns></returns>
        public Task<bool> StringSetAsync(string key, string value, TimeSpan? expiry = null)
        {
            key = AddPreFixKey(key);
            return Do(db => db.StringSetAsync(key, value, expiry));
        }

        /// <summary>
        /// 保存多个key value
        /// </summary>
        /// <param name="keyValues">键值对</param>
        /// <returns></returns>
        public Task<bool> StringSetAsync(KeyValuePair<string, string>[] keyValues)
        {
            KeyValuePair<RedisKey, RedisValue>[] newkeyValues =
                keyValues.Select(p => new KeyValuePair<RedisKey, RedisValue>(AddPreFixKey(p.Key), p.Value)).ToArray();
            return Do(db => db.StringSetAsync(newkeyValues));
        }


        /// <summary>
        /// 获取单个key的值
        /// </summary>
        /// <param name="key">Redis Key</param>
        /// <returns></returns>
        public Task<string> StringGetAsync(string key)
        {
            key = AddPreFixKey(key);
            return Do(db => db.StringGetAsync(key));
        }

        /// <summary>
        /// 获取多个Key
        /// </summary>
        /// <param name="listKey">Redis Key集合</param>
        /// <returns></returns>
        public Task<string[]> StringGetAsync(string[] listKey)
        {
            RedisKey[] newKeys = listKey.Select(AddPreFixKey).ToArray();
            return Do(db => db.StringGetAsync(newKeys));

        }


        /// <summary>
        /// 为数字增长val
        /// </summary>
        /// <param name="key"></param>
        /// <param name="val">可以为负</param>
        /// <returns>增长后的值</returns>
        public Task<double> StringIncrementAsync(string key, double val = 1)
        {
            key = AddPreFixKey(key);
            return Do(db => db.StringIncrementAsync(key, val));
        }

        /// <summary>
        /// 为数字减少val
        /// </summary>
        /// <param name="key"></param>
        /// <param name="val">可以为负</param>
        /// <returns>减少后的值</returns>
        public Task<double> StringDecrementAsync(string key, double val = 1)
        {
            key = AddPreFixKey(key);
            return Do(db => db.StringDecrementAsync(key, val));
        }
    }
}
