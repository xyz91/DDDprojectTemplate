using StackExchange.Redis;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace MeidPlus.Repository.RedisRepository
{
    public partial class RedisBaseRepository
    {


        /// <summary>
        /// 判断某个数据是否已经被缓存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="dataKey"></param>
        /// <returns></returns>
        public bool HashExists(string key, string dataKey)
        {
            key = AddPreFixKey(key);
            return Do(db => db.HashExists(key, dataKey));
        }

        /// <summary>
        /// 存储数据到hash表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="dataKey"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        private bool HashSet(string key, string dataKey, RedisValue t)
        {
            key = AddPreFixKey(key);
            return Do(db => db.HashSet(key, dataKey, t));
        }
        /// <summary>
        /// 存储hash数据
        /// </summary>
        /// <param name="key"></param>
        /// <param name="pairs"></param>
        public void HashSet(string key ,KeyValuePair<string,string>[] pairs) {
            key = AddPreFixKey(key);
            if (pairs.Length > 0)
            {
                HashEntry[] hashes = new HashEntry[pairs.Length];
                for (int i = 0; i < pairs.Length; i++)
                {
                    hashes[i] = new HashEntry(pairs[i].Key, pairs[i].Value);
                }
                 Do(db => db.HashSet(key,hashes));
            }
        }
        /// <summary>
        /// 存储数据到hash表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="dataKey"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool HashSet(string key, string dataKey, string t) => HashSet(key, dataKey, (RedisValue)t);
        /// <summary>
        /// 存储数据到hash表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="dataKey"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool HashSet(string key, string dataKey, int t) => HashSet(key, dataKey, (RedisValue)t);
        /// <summary>
        /// 存储数据到hash表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="dataKey"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool HashSet(string key, string dataKey, short t) => HashSet(key, dataKey, (RedisValue)t);
        /// <summary>
        /// 存储数据到hash表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="dataKey"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool HashSet(string key, string dataKey, long t) => HashSet(key, dataKey, (RedisValue)t);
        /// <summary>
        /// 存储数据到hash表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="dataKey"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool HashSet(string key, string dataKey, float t) => HashSet(key, dataKey, (RedisValue)t);
        /// <summary>
        /// 存储数据到hash表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="dataKey"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool HashSet(string key, string dataKey, double t) => HashSet(key, dataKey, (RedisValue)t);

        /// <summary>
        /// 移除hash中的多个值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="dataKeys"></param>
        /// <returns></returns>
        public long HashDelete(string key, params string[] dataKeys)
        {
            key = AddPreFixKey(key);
            return Do(db => db.HashDelete(key, dataKeys.Select(a => (RedisValue)a).ToArray()));
        }

        /// <summary>
        /// 从hash表获取数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="dataKey"></param>
        /// <returns></returns>
        public string HashGet(string key, string dataKey)
        {
            key = AddPreFixKey(key);
            return Do(db => db.HashGet(key, dataKey));
        }

        /// <summary>
        /// 为数字增长val
        /// </summary>
        /// <param name="key"></param>
        /// <param name="dataKey"></param>
        /// <param name="val">可以为负</param>
        /// <returns>增长后的值</returns>
        public double HashIncrement(string key, string dataKey, double val = 1)
        {
            key = AddPreFixKey(key);
            return Do(db => db.HashIncrement(key, dataKey, val));
        }

        /// <summary>
        /// 为数字减少val
        /// </summary>
        /// <param name="key"></param>
        /// <param name="dataKey"></param>
        /// <param name="val">可以为负</param>
        /// <returns>减少后的值</returns>
        public double HashDecrement(string key, string dataKey, double val = 1)
        {
            key = AddPreFixKey(key);
            return Do(db => db.HashDecrement(key, dataKey, val));
        }

        /// <summary>
        /// 获取hashkey所有field name
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public string[] HashKeys<T>(string key)
        {
            key = AddPreFixKey(key);
            return Do(db =>db.HashKeys(key));
        }



        /// <summary>
        /// 判断某个数据是否已经被缓存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="dataKey"></param>
        /// <returns></returns>
        public Task<bool> HashExistsAsync(string key, string dataKey)
        {
            key = AddPreFixKey(key);
            return Do(db => db.HashExistsAsync(key, dataKey));
        }
        private Task<bool> HashSetAsync(string key, string dataKey, RedisValue t) => Do(db => db.HashSetAsync(key, dataKey, t));
        /// <summary>
        /// 存储数据到hash表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="dataKey"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public Task<bool> HashSetAsync(string key, string dataKey, string t) => HashSetAsync(key, dataKey, (RedisValue)t);
        /// <summary>
        /// 存储数据到hash表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="dataKey"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public Task<bool> HashSetAsync(string key, string dataKey, int t) => HashSetAsync(key, dataKey, (RedisValue)t);
        /// <summary>
        /// 存储数据到hash表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="dataKey"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public Task<bool> HashSetAsync(string key, string dataKey, short t) => HashSetAsync(key, dataKey, (RedisValue)t);
        /// <summary>
        /// 存储数据到hash表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="dataKey"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public Task<bool> HashSetAsync(string key, string dataKey, long t) => HashSetAsync(key, dataKey, (RedisValue)t);
        /// <summary>
        /// 存储数据到hash表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="dataKey"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public Task<bool> HashSetAsync(string key, string dataKey, float t) => HashSetAsync(key, dataKey, (RedisValue)t);
        /// <summary>
        /// 存储数据到hash表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="dataKey"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public Task<bool> HashSetAsync(string key, string dataKey, double t) => HashSetAsync(key, dataKey, (RedisValue)t);

        /// <summary>
        /// 移除hash中的指定field的值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="dataKeys"></param>
        /// <returns></returns>
        public  Task<long> HashDeleteAsync(string key, params string[] dataKeys)
        {
            key = AddPreFixKey(key);
            return  Do(db => db.HashDeleteAsync(key, dataKeys.Select(a => (RedisValue)a).ToArray()));
        }

        /// <summary>
        /// 从hash表获取数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="dataKey"></param>
        /// <returns></returns>
        public  Task<string> HashGeAsync<T>(string key, string dataKey)
        {
            key = AddPreFixKey(key);
            return  Do(db => db.HashGetAsync(key, dataKey));
        }

        /// <summary>
        /// 为数字增长val
        /// </summary>
        /// <param name="key"></param>
        /// <param name="dataKey"></param>
        /// <param name="val">可以为负</param>
        /// <returns>增长后的值</returns>
        public Task<double> HashIncrementAsync(string key, string dataKey, double val = 1)
        {
            key = AddPreFixKey(key);
            return Do(db => db.HashIncrementAsync(key, dataKey, val));
        }

        /// <summary>
        /// 为数字减少val
        /// </summary>
        /// <param name="key"></param>
        /// <param name="dataKey"></param>
        /// <param name="val">可以为负</param>
        /// <returns>减少后的值</returns>
        public Task<double> HashDecrementAsync(string key, string dataKey, double val = 1)
        {
            key = AddPreFixKey(key);
            return Do(db => db.HashDecrementAsync(key, dataKey, val));
        }

        /// <summary>
        /// 获取hashkey所有Redis key
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public  Task<string[]> HashKeysAsync(string key)
        {
            key = AddPreFixKey(key);
           return Do(db => db.HashKeysAsync(key));
        }
        /// <summary>
        /// 获取key下所有hash数据
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public KeyValuePair<string, string>[] HashGetAll(string key) {
            key = AddPreFixKey(key);
            return Do(db => db.HashGetAll(key));
        }
        /// <summary>
        /// 获取key下所有hash数据
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Task<KeyValuePair<string, string>[]> HashGetAllAsync(string key)
        {
            key = AddPreFixKey(key);
            return Do(db => db.HashGetAllAsync(key));
        }
        /// <summary>
        /// 存储hash数据
        /// </summary>
        /// <param name="key"></param>
        /// <param name="pairs"></param>
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
