using StackExchange.Redis;
using System.Threading.Tasks;

namespace MeidPlus.Repository.RedisRepository
{
    public partial class RedisBaseRepository
    {


        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="score"></param>
        private bool SortedSetAdd(string key, RedisValue value, double score)
        {
            key = AddPreFixKey(key);
            return Do(db => db.SortedSetAdd(key, value, score));
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="score"></param>
        public bool SortedSetAdd(string key, string value, double score) => SortedSetAdd(key, (RedisValue)value, score);
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="score"></param>
        public bool SortedSetAdd(string key, int value, double score) => SortedSetAdd(key, (RedisValue)value, score);
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="score"></param>
        public bool SortedSetAdd(string key, short value, double score) => SortedSetAdd(key, (RedisValue)value, score);
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="score"></param>
        public bool SortedSetAdd(string key, long value, double score) => SortedSetAdd(key, (RedisValue)value, score);
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="score"></param>
        public bool SortedSetAdd(string key, float value, double score) => SortedSetAdd(key, (RedisValue)value, score);
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="score"></param>
        public bool SortedSetAdd(string key, double value, double score) => SortedSetAdd(key, (RedisValue)value, score);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        private bool SortedSetRemove(string key, RedisValue value)
        {
            key = AddPreFixKey(key);
            return Do(db => db.SortedSetRemove(key, value));
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public bool SortedSetRemove(string key, int value) => SortedSetRemove(key, (RedisValue)value);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public bool SortedSetRemove(string key, string value) => SortedSetRemove(key, (RedisValue)value);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public bool SortedSetRemove(string key, short value) => SortedSetRemove(key, (RedisValue)value);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public bool SortedSetRemove(string key, long value) => SortedSetRemove(key, (RedisValue)value);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public bool SortedSetRemove(string key, float value) => SortedSetRemove(key, (RedisValue)value);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public bool SortedSetRemove(string key, double value) => SortedSetRemove(key, (RedisValue)value);
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="start">开始</param>
        /// <param name="end">结束</param>
        /// <param name="asc">排序</param>
        /// <returns></returns>
        public string[] SortedSetRangeByRank(string key, long start = 0, long end = -1, bool asc = true)
        {
            key = AddPreFixKey(key);
            return Do(db => db.SortedSetRangeByRank(key, start, end, asc ? Order.Ascending : Order.Descending));
        }

        /// <summary>
        /// 获取集合中数量
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="min">score最小值</param>
        /// <param name="max">score最大值</param>
        /// <returns></returns>
        public long SortedSetLength(string key, double min = double.NegativeInfinity, double max = double.PositiveInfinity)
        {
            key = AddPreFixKey(key);
            return Do(db => db.SortedSetLength(key, min, max));
        }




        private Task<bool> SortedSetAddAsync(string key, RedisValue value, double score)
        {
            key = AddPreFixKey(key);
            return Do(db => db.SortedSetAddAsync(key, value, score));
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="score"></param>
        public Task<bool> SortedSetAddAsync(string key, string value, double score) => SortedSetAddAsync(key, (RedisValue)value, score);
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="score"></param>
        public Task<bool> SortedSetAddAsync(string key, int value, double score) => SortedSetAddAsync(key, (RedisValue)value, score);
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="score"></param>
        public Task<bool> SortedSetAddAsync(string key, short value, double score) => SortedSetAddAsync(key, (RedisValue)value, score);
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="score"></param>
        public Task<bool> SortedSetAddAsync(string key, long value, double score) => SortedSetAddAsync(key, (RedisValue)value, score);
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="score"></param>
        public Task<bool> SortedSetAddAsync(string key, double value, double score) => SortedSetAddAsync(key, (RedisValue)value, score);
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="score"></param>
        public Task<bool> SortedSetAddAsync(string key, float value, double score) => SortedSetAddAsync(key, (RedisValue)value, score);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        private Task<bool> SortedSetRemoveAsync(string key, RedisValue value)
        {
            key = AddPreFixKey(key);
            return Do(redis => redis.SortedSetRemoveAsync(key, value));
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public Task<bool> SortedSetRemoveAsync(string key, string value) => SortedSetRemoveAsync(key, (RedisValue)value);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public Task<bool> SortedSetRemoveAsync(string key, int value) => SortedSetRemoveAsync(key, (RedisValue)value);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public Task<bool> SortedSetRemoveAsync(string key, short value) => SortedSetRemoveAsync(key, (RedisValue)value);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public Task<bool> SortedSetRemoveAsync(string key, long value) => SortedSetRemoveAsync(key, (RedisValue)value);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public Task<bool> SortedSetRemoveAsync(string key, float value) => SortedSetRemoveAsync(key, (RedisValue)value);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public Task<bool> SortedSetRemoveAsync(string key, double value) => SortedSetRemoveAsync(key, (RedisValue)value);

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="start">开始</param>
        /// <param name="end">结束</param>
        /// <param name="asc">排序</param>
        /// <returns></returns>
        public Task<string[]> SortedSetRangeByRankAsync(string key, long start = 0, long end = -1, bool asc = true)
        {
            key = AddPreFixKey(key);
            return Do(db => db.SortedSetRangeByRankAsync(key, start, end, asc ? Order.Ascending : Order.Descending));
        }

        /// <summary>
        /// 获取集合中数量
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <returns></returns>
        public Task<long> SortedSetLengthAsync(string key, double min = double.NegativeInfinity, double max = double.PositiveInfinity)
        {
            key = AddPreFixKey(key);
            return Do(db => db.SortedSetLengthAsync(key, min, max));
        }


    }
}
