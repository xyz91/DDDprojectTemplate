using StackExchange.Redis;
using System.Threading.Tasks;

namespace MeidPlus.Repository.RedisRepository
{
    public partial class RedisBaseRepository
    {

        private long ListRemove(string key, RedisValue value, long count)
        {
            key = AddPreFixKey(key);
            return Do(db => db.ListRemove(key, value, count));
        }
        /// <summary>
        /// 删除list中等于指定值的对象
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="value">指定值</param>
        /// <param name="count">大于0:从头到尾删除count个,小于0从尾到头删除，等于0删除全部</param>
        /// <returns></returns>
        public long ListRemove(string key, string value, long count = 0) => ListRemove(key, (RedisValue)value, count);
        /// <summary>
        /// 删除list中等于指定值的对象
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="value">指定值</param>
        /// <param name="count">大于0:从头到尾删除count个,小于0从尾到头删除，等于0删除全部</param>
        /// <returns></returns>
        public long ListRemove(string key, int value, long count = 0) => ListRemove(key, (RedisValue)value, count);
        /// <summary>
        /// 删除list中等于指定值的对象
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="value">指定值</param>
        /// <param name="count">大于0:从头到尾删除count个,小于0从尾到头删除，等于0删除全部</param>
        /// <returns></returns>
        public long ListRemove(string key, short value, long count = 0) => ListRemove(key, (RedisValue)value, count);
        /// <summary>
        /// 删除list中等于指定值的对象
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="value">指定值</param>
        /// <param name="count">大于0:从头到尾删除count个,小于0从尾到头删除，等于0删除全部</param>
        /// <returns></returns>
        public long ListRemove(string key, long value, long count = 0) => ListRemove(key, (RedisValue)value, count);
        /// <summary>
        /// 删除list中等于指定值的对象
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="value">指定值</param>
        /// <param name="count">大于0:从头到尾删除count个,小于0从尾到头删除，等于0删除全部</param>
        /// <returns></returns>
        public long ListRemove(string key, float value, long count = 0) => ListRemove(key, (RedisValue)value, count);
        /// <summary>
        /// 删除list中等于指定值的对象
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="value">指定值</param>
        /// <param name="count">大于0:从头到尾删除count个,小于0从尾到头删除，等于0删除全部</param>
        /// <returns></returns>
        public long ListRemove(string key, double value, long count = 0) => ListRemove(key, (RedisValue)value, count);

        /// <summary>
        /// 获取list中的对象
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="start">序列开始值,可以为负表示倒序计算</param>
        /// <param name="end">序列结束值，可以为负表示倒序计算</param>
        /// <returns></returns>
        public string[] ListRange(string key, long start = 0, long end = -1)
        {
            key = AddPreFixKey(key);
            return Do(db => db.ListRange(key, start, end));
        }

        /// <summary>
        /// 入队
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        private long ListRightPush(string key, RedisValue value)
        {
            key = AddPreFixKey(key);
            return Do(db => db.ListRightPush(key, value));
        }
        /// <summary>
        /// 入队
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public long ListRightPush(string key, string value) => ListRightPush(key, (RedisValue)value);
        /// <summary>
        /// 入队
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public long ListRightPush(string key, int value) => ListRightPush(key, (RedisValue)value);
        /// <summary>
        /// 入队
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public long ListRightPush(string key, short value) => ListRightPush(key, (RedisValue)value);
        /// <summary>
        /// 入队
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public long ListRightPush(string key, long value) => ListRightPush(key, (RedisValue)value);
        /// <summary>
        /// 入队
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public long ListRightPush(string key, float value) => ListRightPush(key, (RedisValue)value);
        /// <summary>
        /// 入队
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public long ListRightPush(string key, double value) => ListRightPush(key, (RedisValue)value);


        /// <summary>
        /// 出队
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string ListRightPop(string key)
        {
            key = AddPreFixKey(key);
            return Do(db => db.ListRightPop(key));
        }

        /// <summary>
        /// 入栈
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        private long ListLeftPush(string key, RedisValue value)
        {
            key = AddPreFixKey(key);
            return Do(db => db.ListLeftPush(key, value));
        }
        /// <summary>
        /// 入栈
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public long ListLeftPush(string key, string value) => ListLeftPush(key, (RedisValue)value);
        /// <summary>
        /// 入栈
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public long ListLeftPush(string key, int value) => ListLeftPush(key, (RedisValue)value);
        /// <summary>
        /// 入栈
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public long ListLeftPush(string key, short value) => ListLeftPush(key, (RedisValue)value);
        /// <summary>
        /// 入栈
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public long ListLeftPush(string key, long value) => ListLeftPush(key, (RedisValue)value);
        /// <summary>
        /// 入栈
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public long ListLeftPush(string key, float value) => ListLeftPush(key, (RedisValue)value);
        /// <summary>
        /// 入栈
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public long ListLeftPush(string key, double value) => ListLeftPush(key, (RedisValue)value);

        /// <summary>
        /// 出栈
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string ListLeftPop(string key)
        {
            key = AddPreFixKey(key);
            return Do(db => db.ListLeftPop(key));
        }

        /// <summary>
        /// 获取集合中的数量
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public long ListLength(string key)
        {
            key = AddPreFixKey(key);
            return Do(db => db.ListLength(key));
        }




        private Task<long> ListRemoveAsync(string key, RedisValue value, long count)
        {
            key = AddPreFixKey(key);
            return Do(db => db.ListRemoveAsync(key, value, count));
        }
        /// <summary>
        /// 删除list中等于指定值的对象
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="value">指定值</param>
        /// <param name="count">大于0:从头到尾删除count个,小于0从尾到头删除，等于0删除全部</param>
        /// <returns></returns>
        public Task<long> ListRemoveAsync(string key, string value, long count = 0) => ListRemoveAsync(key, (RedisValue)value, count);
        /// <summary>
        /// 删除list中等于指定值的对象
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="value">指定值</param>
        /// <param name="count">大于0:从头到尾删除count个,小于0从尾到头删除，等于0删除全部</param>
        /// <returns></returns>
        public Task<long> ListRemoveAsync(string key, int value, long count = 0) => ListRemoveAsync(key, (RedisValue)value, count);
        /// <summary>
        /// 删除list中等于指定值的对象
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="value">指定值</param>
        /// <param name="count">大于0:从头到尾删除count个,小于0从尾到头删除，等于0删除全部</param>
        /// <returns></returns>
        public Task<long> ListRemoveAsync(string key, short value, long count = 0) => ListRemoveAsync(key, (RedisValue)value, count);
        /// <summary>
        /// 删除list中等于指定值的对象
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="value">指定值</param>
        /// <param name="count">大于0:从头到尾删除count个,小于0从尾到头删除，等于0删除全部</param>
        /// <returns></returns>
        public Task<long> ListRemoveAsync(string key, long value, long count = 0) => ListRemoveAsync(key, (RedisValue)value, count);
        /// <summary>
        /// 删除list中等于指定值的对象
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="value">指定值</param>
        /// <param name="count">大于0:从头到尾删除count个,小于0从尾到头删除，等于0删除全部</param>
        /// <returns></returns>
        public Task<long> ListRemoveAsync(string key, float value, long count = 0) => ListRemoveAsync(key, (RedisValue)value, count);
        /// <summary>
        /// 删除list中等于指定值的对象
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="value">指定值</param>
        /// <param name="count">大于0:从头到尾删除count个,小于0从尾到头删除，等于0删除全部</param>
        /// <returns></returns>
        public Task<long> ListRemoveAsync(string key, double value, long count = 0) => ListRemoveAsync(key, (RedisValue)value, count);
        /// <summary>
        /// 获取指定key 指定序列的值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">key</param>
        /// <param name="start">开始值 可倒序</param>
        /// <param name="end">结束值 可倒序</param>
        /// <returns></returns>
        public Task<string[]> ListRangeAsync<T>(string key, long start = 0, long end = -1)
        {
            key = AddPreFixKey(key);
            return Do(redis => redis.ListRangeAsync(key, start, end));
        }

        /// <summary>
        /// 入队
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        private Task<long> ListRightPushAsync(string key, RedisValue value)
        {
            key = AddPreFixKey(key);
            return Do(db => db.ListRightPushAsync(key, value));
        }
        /// <summary>
        /// 入队
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public Task<long> ListRightPushAsync(string key, string value) => ListRightPushAsync(key, (RedisValue)value);
        /// <summary>
        /// 入队
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public Task<long> ListRightPushAsync(string key, int value) => ListRightPushAsync(key, (RedisValue)value);
        /// <summary>
        /// 入队
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public Task<long> ListRightPushAsync(string key, short value) => ListRightPushAsync(key, (RedisValue)value);
        /// <summary>
        /// 入队
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public Task<long> ListRightPushAsync(string key, float value) => ListRightPushAsync(key, (RedisValue)value);
        /// <summary>
        /// 入队
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public Task<long> ListRightPushAsync(string key, long value) => ListRightPushAsync(key, (RedisValue)value);
        /// <summary>
        /// 入队
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public Task<long> ListRightPushAsync(string key, double value) => ListRightPushAsync(key, (RedisValue)value);
        /// <summary>
        /// 出队
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public Task<string> ListRightPopAsync(string key)
        {
            key = AddPreFixKey(key);
            return Do(db => db.ListRightPopAsync(key));
        }

        /// <summary>
        /// 入栈
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        private Task<long> ListLeftPushAsync(string key, RedisValue value)
        {
            key = AddPreFixKey(key);
            return Do(db => db.ListLeftPushAsync(key, value));
        }
        /// <summary>
        /// 入栈
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public Task<long> ListLeftPushAsync(string key, string value) => ListLeftPushAsync(key, (RedisValue)value);
        /// <summary>
        /// 入栈
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public Task<long> ListLeftPushAsync(string key, int value) => ListLeftPushAsync(key, (RedisValue)value);
        /// <summary>
        /// 入栈
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public Task<long> ListLeftPushAsync(string key, short value) => ListLeftPushAsync(key, (RedisValue)value);
        /// <summary>
        /// 入栈
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public Task<long> ListLeftPushAsync(string key, long value) => ListLeftPushAsync(key, (RedisValue)value);
        /// <summary>
        /// 入栈
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public Task<long> ListLeftPushAsync(string key, float value) => ListLeftPushAsync(key, (RedisValue)value);
        /// <summary>
        /// 入栈
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public Task<long> ListLeftPushAsync(string key, double value) => ListLeftPushAsync(key, (RedisValue)value);


        /// <summary>
        /// 出栈
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public Task<string> ListLeftPopAsync(string key)
        {
            key = AddPreFixKey(key);
            return Do(db => db.ListLeftPopAsync(key));
        }

        /// <summary>
        /// 获取集合中的数量
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Task<long> ListLengthAsync(string key)
        {
            key = AddPreFixKey(key);
            return Do(redis => redis.ListLengthAsync(key));
        }


    }
}
