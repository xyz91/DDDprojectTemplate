using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MediPlus.Domain.IRepositories.BaseRepository
{
    public interface IRedisRepository
    {
        #region hash
        /// <summary>
        /// 判断某个数据是否已经被缓存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="dataKey"></param>
        /// <returns></returns>
        bool HashExists(string key, string dataKey);



        /// <summary>
        /// 存储hash数据
        /// </summary>
        /// <param name="key"></param>
        /// <param name="pairs"></param>
        void HashSet(string key, KeyValuePair<string, string>[] pairs);

        /// <summary>
        /// 存储数据到hash表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="dataKey"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        bool HashSet(string key, string dataKey, string t);
        /// <summary>
        /// 存储数据到hash表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="dataKey"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        bool HashSet(string key, string dataKey, int t);
        /// <summary>
        /// 存储数据到hash表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="dataKey"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        bool HashSet(string key, string dataKey, short t);
        /// <summary>
        /// 存储数据到hash表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="dataKey"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        bool HashSet(string key, string dataKey, long t);
        /// <summary>
        /// 存储数据到hash表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="dataKey"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        bool HashSet(string key, string dataKey, float t);
        /// <summary>
        /// 存储数据到hash表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="dataKey"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        bool HashSet(string key, string dataKey, double t);

        /// <summary>
        /// 移除hash中的多个值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="dataKeys"></param>
        /// <returns></returns>
        long HashDelete(string key, params string[] dataKeys);


        /// <summary>
        /// 从hash表获取数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="dataKey"></param>
        /// <returns></returns>
        string HashGet(string key, string dataKey);


        /// <summary>
        /// 为数字增长val
        /// </summary>
        /// <param name="key"></param>
        /// <param name="dataKey"></param>
        /// <param name="val">可以为负</param>
        /// <returns>增长后的值</returns>
        double HashIncrement(string key, string dataKey, double val = 1);

        /// <summary>
        /// 为数字减少val
        /// </summary>
        /// <param name="key"></param>
        /// <param name="dataKey"></param>
        /// <param name="val">可以为负</param>
        /// <returns>减少后的值</returns>
        double HashDecrement(string key, string dataKey, double val = 1);

        /// <summary>
        /// 获取hashkey所有field name
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        string[] HashKeys<T>(string key);



        /// <summary>
        /// 判断某个数据是否已经被缓存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="dataKey"></param>
        /// <returns></returns>
        Task<bool> HashExistsAsync(string key, string dataKey);


        /// <summary>
        /// 存储数据到hash表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="dataKey"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        Task<bool> HashSetAsync(string key, string dataKey, string t);
        /// <summary>
        /// 存储数据到hash表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="dataKey"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        Task<bool> HashSetAsync(string key, string dataKey, int t);
        /// <summary>
        /// 存储数据到hash表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="dataKey"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        Task<bool> HashSetAsync(string key, string dataKey, short t);
        /// <summary>
        /// 存储数据到hash表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="dataKey"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        Task<bool> HashSetAsync(string key, string dataKey, long t);
        /// <summary>
        /// 存储数据到hash表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="dataKey"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        Task<bool> HashSetAsync(string key, string dataKey, float t);
        /// <summary>
        /// 存储数据到hash表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="dataKey"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        Task<bool> HashSetAsync(string key, string dataKey, double t);

        /// <summary>
        /// 移除hash中的指定field的值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="dataKeys"></param>
        /// <returns></returns>
        Task<long> HashDeleteAsync(string key, params string[] dataKeys);


        /// <summary>
        /// 从hash表获取数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="dataKey"></param>
        /// <returns></returns>
        Task<string> HashGeAsync<T>(string key, string dataKey);


        /// <summary>
        /// 为数字增长val
        /// </summary>
        /// <param name="key"></param>
        /// <param name="dataKey"></param>
        /// <param name="val">可以为负</param>
        /// <returns>增长后的值</returns>
        Task<double> HashIncrementAsync(string key, string dataKey, double val = 1);


        /// <summary>
        /// 为数字减少val
        /// </summary>
        /// <param name="key"></param>
        /// <param name="dataKey"></param>
        /// <param name="val">可以为负</param>
        /// <returns>减少后的值</returns>
        Task<double> HashDecrementAsync(string key, string dataKey, double val = 1);

        /// <summary>
        /// 获取hashkey所有Redis key
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<string[]> HashKeysAsync(string key);

        /// <summary>
        /// 获取key下所有hash数据
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        KeyValuePair<string, string>[] HashGetAll(string key);

        /// <summary>
        /// 获取key下所有hash数据
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<KeyValuePair<string, string>[]> HashGetAllAsync(string key);

        /// <summary>
        /// 存储hash数据
        /// </summary>
        /// <param name="key"></param>
        /// <param name="pairs"></param>
        void HashSetAsync(string key, KeyValuePair<string, string>[] pairs);


        #endregion

        #region key
        /// <summary>
        /// 删除key
        /// </summary>
        /// <param name="keys">rediskey</param>
        /// <returns>成功删除的个数</returns>
        long KeyDelete(params string[] keys);

        /// <summary>
        /// 异步删除key
        /// </summary>
        /// <param name="keys">rediskey</param>
        /// <returns>成功删除的个数</returns>
        Task<long> KeyDeleteAsync(params string[] keys);

        /// <summary>
        /// 判断key是否存储
        /// </summary>
        /// <param name="key">redis key</param>
        /// <returns></returns>
        bool KeyExists(string key);

        /// <summary>
        /// 异步判断key是否存储
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<bool> KeyExistsAsync(string key);

        /// <summary>
        /// 重新命名key
        /// </summary>
        /// <param name="key">就的redis key</param>
        /// <param name="newKey">新的redis key</param>
        /// <returns></returns>
        bool KeyRename(string key, string newKey);

        /// <summary>
        /// 重新命名key
        /// </summary>
        /// <param name="key">就的redis key</param>
        /// <param name="newKey">新的redis key</param>
        /// <returns></returns>
        Task<bool> KeyRenameAsync(string key, string newKey);


        /// <summary>
        /// 设置Key的时间
        /// </summary>
        /// <param name="key">redis key</param>
        /// <param name="expiry"></param>
        /// <returns></returns>
        bool KeyExpire(string key, TimeSpan? expiry = null);

        /// <summary>
        /// 设置Key的时间
        /// </summary>
        /// <param name="key">redis key</param>
        /// <param name="expiry"></param>
        /// <returns></returns>
        Task<bool> KeyExpireAsync(string key, TimeSpan? expiry = null);

        #endregion

        #region list
        /// <summary>
        /// 删除list中等于指定值的对象
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="value">指定值</param>
        /// <param name="count">大于0:从头到尾删除count个,小于0从尾到头删除，等于0删除全部</param>
        /// <returns></returns>
        long ListRemove(string key, string value, long count = 0);

        /// <summary>
        /// 删除list中等于指定值的对象
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="value">指定值</param>
        /// <param name="count">大于0:从头到尾删除count个,小于0从尾到头删除，等于0删除全部</param>
        /// <returns></returns>
        long ListRemove(string key, int value, long count = 0);

        /// <summary>
        /// 删除list中等于指定值的对象
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="value">指定值</param>
        /// <param name="count">大于0:从头到尾删除count个,小于0从尾到头删除，等于0删除全部</param>
        /// <returns></returns>
        long ListRemove(string key, short value, long count = 0);

        /// <summary>
        /// 删除list中等于指定值的对象
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="value">指定值</param>
        /// <param name="count">大于0:从头到尾删除count个,小于0从尾到头删除，等于0删除全部</param>
        /// <returns></returns>
        long ListRemove(string key, long value, long count = 0);

        /// <summary>
        /// 删除list中等于指定值的对象
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="value">指定值</param>
        /// <param name="count">大于0:从头到尾删除count个,小于0从尾到头删除，等于0删除全部</param>
        /// <returns></returns>
        long ListRemove(string key, float value, long count = 0);

        /// <summary>
        /// 删除list中等于指定值的对象
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="value">指定值</param>
        /// <param name="count">大于0:从头到尾删除count个,小于0从尾到头删除，等于0删除全部</param>
        /// <returns></returns>
        long ListRemove(string key, double value, long count = 0);


        /// <summary>
        /// 获取list中的对象
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="start">序列开始值,可以为负表示倒序计算</param>
        /// <param name="end">序列结束值，可以为负表示倒序计算</param>
        /// <returns></returns>
        string[] ListRange(string key, long start = 0, long end = -1);



        /// <summary>
        /// 入队
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        long ListRightPush(string key, string value);

        /// <summary>
        /// 入队
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        long ListRightPush(string key, int value);

        /// <summary>
        /// 入队
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        long ListRightPush(string key, short value);

        /// <summary>
        /// 入队
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        long ListRightPush(string key, long value);

        /// <summary>
        /// 入队
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        long ListRightPush(string key, float value);

        /// <summary>
        /// 入队
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        long ListRightPush(string key, double value);



        /// <summary>
        /// 出队
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        string ListRightPop(string key);



        /// <summary>
        /// 入栈
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        long ListLeftPush(string key, string value);

        /// <summary>
        /// 入栈
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        long ListLeftPush(string key, int value);

        /// <summary>
        /// 入栈
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        long ListLeftPush(string key, short value);

        /// <summary>
        /// 入栈
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        long ListLeftPush(string key, long value);

        /// <summary>
        /// 入栈
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        long ListLeftPush(string key, float value);

        /// <summary>
        /// 入栈
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        long ListLeftPush(string key, double value);


        /// <summary>
        /// 出栈
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        string ListLeftPop(string key);


        /// <summary>
        /// 获取集合中的数量
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        long ListLength(string key);

        /// <summary>
        /// 删除list中等于指定值的对象
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="value">指定值</param>
        /// <param name="count">大于0:从头到尾删除count个,小于0从尾到头删除，等于0删除全部</param>
        /// <returns></returns>
        Task<long> ListRemoveAsync(string key, string value, long count = 0);

        /// <summary>
        /// 删除list中等于指定值的对象
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="value">指定值</param>
        /// <param name="count">大于0:从头到尾删除count个,小于0从尾到头删除，等于0删除全部</param>
        /// <returns></returns>
        Task<long> ListRemoveAsync(string key, int value, long count = 0);

        /// <summary>
        /// 删除list中等于指定值的对象
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="value">指定值</param>
        /// <param name="count">大于0:从头到尾删除count个,小于0从尾到头删除，等于0删除全部</param>
        /// <returns></returns>
        Task<long> ListRemoveAsync(string key, short value, long count = 0);

        /// <summary>
        /// 删除list中等于指定值的对象
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="value">指定值</param>
        /// <param name="count">大于0:从头到尾删除count个,小于0从尾到头删除，等于0删除全部</param>
        /// <returns></returns>
        Task<long> ListRemoveAsync(string key, long value, long count = 0);

        /// <summary>
        /// 删除list中等于指定值的对象
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="value">指定值</param>
        /// <param name="count">大于0:从头到尾删除count个,小于0从尾到头删除，等于0删除全部</param>
        /// <returns></returns>
        Task<long> ListRemoveAsync(string key, float value, long count = 0);

        /// <summary>
        /// 删除list中等于指定值的对象
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="value">指定值</param>
        /// <param name="count">大于0:从头到尾删除count个,小于0从尾到头删除，等于0删除全部</param>
        /// <returns></returns>
        Task<long> ListRemoveAsync(string key, double value, long count = 0);

        /// <summary>
        /// 获取指定key 指定序列的值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">key</param>
        /// <param name="start">开始值 可倒序</param>
        /// <param name="end">结束值 可倒序</param>
        /// <returns></returns>
        Task<string[]> ListRangeAsync<T>(string key, long start = 0, long end = -1);




        /// <summary>
        /// 入队
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        Task<long> ListRightPushAsync(string key, string value);

        /// <summary>
        /// 入队
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        Task<long> ListRightPushAsync(string key, int value);

        /// <summary>
        /// 入队
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        Task<long> ListRightPushAsync(string key, short value);

        /// <summary>
        /// 入队
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        Task<long> ListRightPushAsync(string key, float value);

        /// <summary>
        /// 入队
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        Task<long> ListRightPushAsync(string key, long value);

        /// <summary>
        /// 入队
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        Task<long> ListRightPushAsync(string key, double value);

        /// <summary>
        /// 出队
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<string> ListRightPopAsync(string key);



        /// <summary>
        /// 入栈
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        Task<long> ListLeftPushAsync(string key, string value);

        /// <summary>
        /// 入栈
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        Task<long> ListLeftPushAsync(string key, int value);

        /// <summary>
        /// 入栈
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        Task<long> ListLeftPushAsync(string key, short value);

        /// <summary>
        /// 入栈
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        Task<long> ListLeftPushAsync(string key, long value);

        /// <summary>
        /// 入栈
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        Task<long> ListLeftPushAsync(string key, float value);

        /// <summary>
        /// 入栈
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        Task<long> ListLeftPushAsync(string key, double value);



        /// <summary>
        /// 出栈
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<string> ListLeftPopAsync(string key);


        /// <summary>
        /// 获取集合中的数量
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<long> ListLengthAsync(string key);




        #endregion

        #region sorted set

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="score"></param>
        bool SortedSetAdd(string key, string value, double score);

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="score"></param>
        bool SortedSetAdd(string key, int value, double score);

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="score"></param>
        bool SortedSetAdd(string key, short value, double score);

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="score"></param>
        bool SortedSetAdd(string key, long value, double score);

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="score"></param>
        bool SortedSetAdd(string key, float value, double score);

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="score"></param>
        bool SortedSetAdd(string key, double value, double score);


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        bool SortedSetRemove(string key, int value);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        bool SortedSetRemove(string key, string value);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        bool SortedSetRemove(string key, short value);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        bool SortedSetRemove(string key, long value);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        bool SortedSetRemove(string key, float value);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        bool SortedSetRemove(string key, double value);

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="start">开始</param>
        /// <param name="end">结束</param>
        /// <param name="asc">排序</param>
        /// <returns></returns>
        string[] SortedSetRangeByRank(string key, long start = 0, long end = -1, bool asc = true);


        /// <summary>
        /// 获取集合中数量
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="min">score最小值</param>
        /// <param name="max">score最大值</param>
        /// <returns></returns>
        long SortedSetLength(string key, double min = double.NegativeInfinity, double max = double.PositiveInfinity);






        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="score"></param>
        Task<bool> SortedSetAddAsync(string key, string value, double score);

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="score"></param>
        Task<bool> SortedSetAddAsync(string key, int value, double score);

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="score"></param>
        Task<bool> SortedSetAddAsync(string key, short value, double score);

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="score"></param>
        Task<bool> SortedSetAddAsync(string key, long value, double score);

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="score"></param>
        Task<bool> SortedSetAddAsync(string key, double value, double score);

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="score"></param>
        Task<bool> SortedSetAddAsync(string key, float value, double score);



        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        Task<bool> SortedSetRemoveAsync(string key, string value);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        Task<bool> SortedSetRemoveAsync(string key, int value);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        Task<bool> SortedSetRemoveAsync(string key, short value);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        Task<bool> SortedSetRemoveAsync(string key, long value);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        Task<bool> SortedSetRemoveAsync(string key, float value);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        Task<bool> SortedSetRemoveAsync(string key, double value);


        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="start">开始</param>
        /// <param name="end">结束</param>
        /// <param name="asc">排序</param>
        /// <returns></returns>
        Task<string[]> SortedSetRangeByRankAsync(string key, long start = 0, long end = -1, bool asc = true);


        /// <summary>
        /// 获取集合中数量
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <returns></returns>
        Task<long> SortedSetLengthAsync(string key, double min = double.NegativeInfinity, double max = double.PositiveInfinity);


        #endregion

        #region string
        /// <summary>
        /// 保存单个key value
        /// </summary>
        /// <param name="key">Redis Key</param>
        /// <param name="value">保存的值</param>
        /// <param name="expiry">过期时间</param>
        /// <returns></returns>
        bool StringSet(string key, string value, TimeSpan? expiry = null);


        /// <summary>
        /// 保存多个key value
        /// </summary>
        /// <param name="keyValues">键值对</param>
        /// <returns></returns>
        bool StringSet(KeyValuePair<string, string>[] keyValues);



        /// <summary>
        /// 获取单个key的值
        /// </summary>
        /// <param name="key">Redis Key</param>
        /// <returns></returns>
        string StringGet(string key);


        /// <summary>
        /// 获取多个Key
        /// </summary>
        /// <param name="listKey">Redis Key集合</param>
        /// <returns></returns>
        string[] StringGet(string[] listKey);


        /// <summary>
        /// 为数字增长val
        /// </summary>
        /// <param name="key"></param>
        /// <param name="val">可以为负</param>
        /// <returns>增长后的值</returns>
        double StringIncrement(string key, double val = 1);


        /// <summary>
        /// 为数字减少val
        /// </summary>
        /// <param name="key"></param>
        /// <param name="val">可以为负</param>
        /// <returns>减少后的值</returns>
        double StringDecrement(string key, double val = 1);




        /// <summary>
        /// 保存单个key value
        /// </summary>
        /// <param name="key">Redis Key</param>
        /// <param name="value">保存的值</param>
        /// <param name="expiry">过期时间</param>
        /// <returns></returns>
        Task<bool> StringSetAsync(string key, string value, TimeSpan? expiry = null);


        /// <summary>
        /// 保存多个key value
        /// </summary>
        /// <param name="keyValues">键值对</param>
        /// <returns></returns>
        Task<bool> StringSetAsync(KeyValuePair<string, string>[] keyValues);



        /// <summary>
        /// 获取单个key的值
        /// </summary>
        /// <param name="key">Redis Key</param>
        /// <returns></returns>
        Task<string> StringGetAsync(string key);


        /// <summary>
        /// 获取多个Key
        /// </summary>
        /// <param name="listKey">Redis Key集合</param>
        /// <returns></returns>
        Task<string[]> StringGetAsync(string[] listKey);



        /// <summary>
        /// 为数字增长val
        /// </summary>
        /// <param name="key"></param>
        /// <param name="val">可以为负</param>
        /// <returns>增长后的值</returns>
        Task<double> StringIncrementAsync(string key, double val = 1);


        /// <summary>
        /// 为数字减少val
        /// </summary>
        /// <param name="key"></param>
        /// <param name="val">可以为负</param>
        /// <returns>减少后的值</returns>
        Task<double> StringDecrementAsync(string key, double val = 1);

        #endregion

        #region Subscribe
        /// <summary>
        /// Redis发布订阅  订阅
        /// </summary>
        /// <param name="subChannel"></param>
        /// <param name="handler"></param>
        void Subscribe(string subChannel, Action<string, string> handler = null);

        /// <summary>
        /// Redis发布订阅  发布
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="channel"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        long Publish(string channel, string msg);


        /// <summary>
        /// Redis发布订阅  取消订阅
        /// </summary>
        /// <param name="channel"></param>
        void Unsubscribe(string channel);


        /// <summary>
        /// Redis发布订阅  取消全部订阅
        /// </summary>
        void UnsubscribeAll();

        #endregion

        #region lock
        /// <summary>
        /// 加锁
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="time">锁定时间 不传默认30秒</param>
        /// <param name="token">token 不传默认当前机器名</param>
        /// <returns></returns>
        bool Lock(string key, TimeSpan? time = null, string token = null);
        /// <summary>
        /// 释放锁
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="token">token 要和锁定时的token一致</param>
        /// <returns></returns>
        bool UnLock(string key, string token = null);
        /// <summary>
        /// 加锁
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="time">锁定时间 不传默认30秒</param>
        /// <param name="token">token 不传默认当前机器名</param>
        /// <returns></returns>
        Task<bool> LockAsync(string key, TimeSpan? time = null, string token = null);
        /// <summary>
        /// 释放锁
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="token">token 要和锁定时的token一致</param>
        /// <returns></returns>
        Task<bool> UnLockAsync(string key, string token = null);
        /// <summary>
        /// 查询key的token
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        string LockQuery(string key);
        /// <summary>
        /// 查询key的token
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<string> LockQueryAsync(string key);
        #endregion
        #region geo
        /// <summary>
        /// 添加一个位置
        /// </summary>
        /// <param name="key"></param>
        /// <param name="longitude">经度</param>
        /// <param name="latitude">纬度</param>
        /// <param name="geoName">名字</param>
        /// <returns></returns>
        bool GeoAdd(string key, double longitude, double latitude, string geoName);
        /// <summary>
        /// 添加一个位置
        /// </summary>
        /// <param name="key"></param>
        /// <param name="longitude">经度</param>
        /// <param name="latitude">纬度</param>
        /// <param name="geoName">名字</param>
        /// <returns></returns>
        Task<bool> GeoAddAsync(string key, double longitude, double latitude, string geoName);
        /// <summary>
        /// 删除位置
        /// </summary>
        /// <param name="key"></param>
        /// <param name="geoName"></param>
        /// <returns></returns>
        bool GeoRemove(string key, string geoName);

        /// <summary>
        /// 删除位置
        /// </summary>
        /// <param name="key"></param>
        /// <param name="geoName"></param>
        /// <returns></returns>
        Task<bool> GeoRemoveAsync(string key, string geoName);


        /// <summary>
        /// 返回两个地址的距离(m)
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="geoName1">地址1</param>
        /// <param name="geoName2">地址2</param>
        /// <returns></returns>
        double? GeoDist(string key, string geoName1, string geoName2);

        /// <summary>
        /// 返回两个地址的距离(m)
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="geoName1">地址1</param>
        /// <param name="geoName2">地址2</param>
        /// <returns></returns>
        Task<double?> GeoDistAsync(string key, string geoName1, string geoName2);

        /// <summary>
        /// 获取位置
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="geoName">地址</param>
        /// <returns></returns>
        GeoPosition? GeoPos(string key, string geoName);

        /// <summary>
        /// 获取位置
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="geoName">地址</param>
        /// <returns></returns>
        Task<GeoPosition?> GeoPosAsync(string key, string geoName);

        /// <summary>
        /// 查询距离给定位置的一定范围内的地址
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="longitude">经度</param>
        /// <param name="latitude">纬度</param>
        /// <param name="radius">距离(m)</param>
        /// <param name="count">数量</param>
        /// <param name="asc">排序</param>
        GeoRadiusResult[] GeoRadius(string key, double longitude, double latitude, double radius, int count = -1, bool asc = true);

        /// <summary>
        /// 查询指定位置一定范围内的地址
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="geoName">位置</param>
        /// <param name="radius">距离</param>
        /// <param name="count">数量</param>
        /// <param name="asc">排序</param>
        /// <returns></returns>
        GeoRadiusResult[] GeoRadius(string key, string geoName, double radius, int count = -1, bool asc = true);

        /// <summary>
        /// 查询距离给定位置的一定范围内的地址
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="longitude">经度</param>
        /// <param name="latitude">纬度</param>
        /// <param name="radius">距离(m)</param>
        /// <param name="count">数量</param>
        /// <param name="asc">排序</param>
        Task<GeoRadiusResult[]> GeoRadiusAsync(string key, double longitude, double latitude, double radius, int count = -1, bool asc = true);

        /// <summary>
        /// 查询指定位置一定范围内的地址
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="geoName">位置</param>
        /// <param name="radius">距离</param>
        /// <param name="count">数量</param>
        /// <param name="asc">排序</param>
        /// <returns></returns>
        Task<GeoRadiusResult[]> GeoRadiusAsync(string key, string geoName, double radius, int count = -1, bool asc = true);

        #endregion
    }

    public struct GeoRadiusResult
    {
        public string Member { get; set; }
        public double? Distance { get; set; }

        public long? Hash { get; set; }
        public GeoPosition? Position { get; set; }
    }
    public struct GeoPosition
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
