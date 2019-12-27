using StackExchange.Redis;
using System.Threading.Tasks;

namespace MeidPlus.Repository.RedisRepository
{
    public partial class RedisBaseRepository
    {

        private long ListRemove(string key, RedisValue value, long count) => Do(db => db.ListRemove(AddPreFixKey(key), value, count));
        public long ListRemove(string key, string value, long count = 0) => ListRemove(key, (RedisValue)value, count);
        public long ListRemove(string key, int value, long count = 0) => ListRemove(key, (RedisValue)value, count);
        public long ListRemove(string key, short value, long count = 0) => ListRemove(key, (RedisValue)value, count);
        public long ListRemove(string key, long value, long count = 0) => ListRemove(key, (RedisValue)value, count);
        public long ListRemove(string key, float value, long count = 0) => ListRemove(key, (RedisValue)value, count);
        public long ListRemove(string key, double value, long count = 0) => ListRemove(key, (RedisValue)value, count);
        public string[] ListRange(string key, long start = 0, long end = -1) => Do(db => db.ListRange(AddPreFixKey(key), start, end));
        private long ListRightPush(string key, RedisValue value) => Do(db => db.ListRightPush(AddPreFixKey(key), value));
        public long ListRightPush(string key, string value) => ListRightPush(key, (RedisValue)value);
        public long ListRightPush(string key, int value) => ListRightPush(key, (RedisValue)value);
        public long ListRightPush(string key, short value) => ListRightPush(key, (RedisValue)value);
        public long ListRightPush(string key, long value) => ListRightPush(key, (RedisValue)value);
        public long ListRightPush(string key, float value) => ListRightPush(key, (RedisValue)value);
        public long ListRightPush(string key, double value) => ListRightPush(key, (RedisValue)value);
        public string ListRightPop(string key) => Do(db => db.ListRightPop(AddPreFixKey(key)));
        private long ListLeftPush(string key, RedisValue value) => Do(db => db.ListLeftPush(AddPreFixKey(key), value));
        public long ListLeftPush(string key, string value) => ListLeftPush(key, (RedisValue)value);
        public long ListLeftPush(string key, int value) => ListLeftPush(key, (RedisValue)value);
        public long ListLeftPush(string key, short value) => ListLeftPush(key, (RedisValue)value);
        public long ListLeftPush(string key, long value) => ListLeftPush(key, (RedisValue)value);
        public long ListLeftPush(string key, float value) => ListLeftPush(key, (RedisValue)value);
        public long ListLeftPush(string key, double value) => ListLeftPush(key, (RedisValue)value);
        public string ListLeftPop(string key) => Do(db => db.ListLeftPop(AddPreFixKey(key)));
        public long ListLength(string key) => Do(db => db.ListLength(AddPreFixKey(key)));
        private Task<long> ListRemoveAsync(string key, RedisValue value, long count) => Do(db => db.ListRemoveAsync(AddPreFixKey(key), value, count));
        public Task<long> ListRemoveAsync(string key, string value, long count = 0) => ListRemoveAsync(key, (RedisValue)value, count);
        public Task<long> ListRemoveAsync(string key, int value, long count = 0) => ListRemoveAsync(key, (RedisValue)value, count);
        public Task<long> ListRemoveAsync(string key, short value, long count = 0) => ListRemoveAsync(key, (RedisValue)value, count);
        public Task<long> ListRemoveAsync(string key, long value, long count = 0) => ListRemoveAsync(key, (RedisValue)value, count);
        public Task<long> ListRemoveAsync(string key, float value, long count = 0) => ListRemoveAsync(key, (RedisValue)value, count);
        public Task<long> ListRemoveAsync(string key, double value, long count = 0) => ListRemoveAsync(key, (RedisValue)value, count);
        public Task<string[]> ListRangeAsync<T>(string key, long start = 0, long end = -1) => Do(redis => redis.ListRangeAsync(AddPreFixKey(key), start, end));
        private Task<long> ListRightPushAsync(string key, RedisValue value) => Do(db => db.ListRightPushAsync(AddPreFixKey(key), value));
        public Task<long> ListRightPushAsync(string key, string value) => ListRightPushAsync(key, (RedisValue)value);
        public Task<long> ListRightPushAsync(string key, int value) => ListRightPushAsync(key, (RedisValue)value);
        public Task<long> ListRightPushAsync(string key, short value) => ListRightPushAsync(key, (RedisValue)value);
        public Task<long> ListRightPushAsync(string key, float value) => ListRightPushAsync(key, (RedisValue)value);
        public Task<long> ListRightPushAsync(string key, long value) => ListRightPushAsync(key, (RedisValue)value);
        public Task<long> ListRightPushAsync(string key, double value) => ListRightPushAsync(key, (RedisValue)value);
        public Task<string> ListRightPopAsync(string key) => Do(db => db.ListRightPopAsync(AddPreFixKey(key)));
        private Task<long> ListLeftPushAsync(string key, RedisValue value) => Do(db => db.ListLeftPushAsync(AddPreFixKey(key), value));
        public Task<long> ListLeftPushAsync(string key, string value) => ListLeftPushAsync(key, (RedisValue)value);
        public Task<long> ListLeftPushAsync(string key, int value) => ListLeftPushAsync(key, (RedisValue)value);
        public Task<long> ListLeftPushAsync(string key, short value) => ListLeftPushAsync(key, (RedisValue)value);
        public Task<long> ListLeftPushAsync(string key, long value) => ListLeftPushAsync(key, (RedisValue)value);
        public Task<long> ListLeftPushAsync(string key, float value) => ListLeftPushAsync(key, (RedisValue)value);
        public Task<long> ListLeftPushAsync(string key, double value) => ListLeftPushAsync(key, (RedisValue)value);
        public Task<string> ListLeftPopAsync(string key) => Do(db => db.ListLeftPopAsync(AddPreFixKey(key)));
        public Task<long> ListLengthAsync(string key) => Do(redis => redis.ListLengthAsync(AddPreFixKey(key)));


    }
}
