using StackExchange.Redis;
using System.Threading.Tasks;

namespace MeidPlus.Repository.RedisRepository
{
    public partial class RedisBaseRepository
    {
        private bool SortedSetAdd(string key, RedisValue value, double score) => Do(db => db.SortedSetAdd(AddPreFixKey(key), value, score));
        public bool SortedSetAdd(string key, string value, double score) => SortedSetAdd(key, (RedisValue)value, score);
        public bool SortedSetAdd(string key, int value, double score) => SortedSetAdd(key, (RedisValue)value, score);
        public bool SortedSetAdd(string key, short value, double score) => SortedSetAdd(key, (RedisValue)value, score);
        public bool SortedSetAdd(string key, long value, double score) => SortedSetAdd(key, (RedisValue)value, score);
        public bool SortedSetAdd(string key, float value, double score) => SortedSetAdd(key, (RedisValue)value, score);
        public bool SortedSetAdd(string key, double value, double score) => SortedSetAdd(key, (RedisValue)value, score);
        private bool SortedSetRemove(string key, RedisValue value) => Do(db => db.SortedSetRemove(AddPreFixKey(key), value));
        public bool SortedSetRemove(string key, int value) => SortedSetRemove(key, (RedisValue)value);
        public bool SortedSetRemove(string key, string value) => SortedSetRemove(key, (RedisValue)value);
        public bool SortedSetRemove(string key, short value) => SortedSetRemove(key, (RedisValue)value);
        public bool SortedSetRemove(string key, long value) => SortedSetRemove(key, (RedisValue)value);
        public bool SortedSetRemove(string key, float value) => SortedSetRemove(key, (RedisValue)value);
        public bool SortedSetRemove(string key, double value) => SortedSetRemove(key, (RedisValue)value);
        public string[] SortedSetRangeByRank(string key, long start = 0, long end = -1, bool asc = true) => Do(db => db.SortedSetRangeByRank(AddPreFixKey(key), start, end, asc ? Order.Ascending : Order.Descending));
        public long SortedSetLength(string key, double min = double.NegativeInfinity, double max = double.PositiveInfinity) => Do(db => db.SortedSetLength(AddPreFixKey(key), min, max));
        private Task<bool> SortedSetAddAsync(string key, RedisValue value, double score) => Do(db => db.SortedSetAddAsync(AddPreFixKey(key), value, score));
        public Task<bool> SortedSetAddAsync(string key, string value, double score) => SortedSetAddAsync(key, (RedisValue)value, score);
        public Task<bool> SortedSetAddAsync(string key, int value, double score) => SortedSetAddAsync(key, (RedisValue)value, score);
        public Task<bool> SortedSetAddAsync(string key, short value, double score) => SortedSetAddAsync(key, (RedisValue)value, score);
        public Task<bool> SortedSetAddAsync(string key, long value, double score) => SortedSetAddAsync(key, (RedisValue)value, score);
        public Task<bool> SortedSetAddAsync(string key, double value, double score) => SortedSetAddAsync(key, (RedisValue)value, score);
        public Task<bool> SortedSetAddAsync(string key, float value, double score) => SortedSetAddAsync(key, (RedisValue)value, score);
        private Task<bool> SortedSetRemoveAsync(string key, RedisValue value) => Do(redis => redis.SortedSetRemoveAsync(AddPreFixKey(key), value));
        public Task<bool> SortedSetRemoveAsync(string key, string value) => SortedSetRemoveAsync(key, (RedisValue)value);
        public Task<bool> SortedSetRemoveAsync(string key, int value) => SortedSetRemoveAsync(key, (RedisValue)value);
        public Task<bool> SortedSetRemoveAsync(string key, short value) => SortedSetRemoveAsync(key, (RedisValue)value);
        public Task<bool> SortedSetRemoveAsync(string key, long value) => SortedSetRemoveAsync(key, (RedisValue)value);
        public Task<bool> SortedSetRemoveAsync(string key, float value) => SortedSetRemoveAsync(key, (RedisValue)value);
        public Task<bool> SortedSetRemoveAsync(string key, double value) => SortedSetRemoveAsync(key, (RedisValue)value);
        public Task<string[]> SortedSetRangeByRankAsync(string key, long start = 0, long end = -1, bool asc = true) => Do(db => db.SortedSetRangeByRankAsync(AddPreFixKey(key), start, end, asc ? Order.Ascending : Order.Descending));
        public Task<long> SortedSetLengthAsync(string key, double min = double.NegativeInfinity, double max = double.PositiveInfinity) => Do(db => db.SortedSetLengthAsync(AddPreFixKey(key), min, max));


    }
}
