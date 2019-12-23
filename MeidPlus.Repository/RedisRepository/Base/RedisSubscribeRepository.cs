using System;

namespace MeidPlus.Repository.RedisRepository
{
    public partial class RedisBaseRepository
    {

        /// <summary>
        /// Redis发布订阅  订阅
        /// </summary>
        /// <param name="subChannel"></param>
        /// <param name="handler"></param>
        public void Subscribe(string subChannel, Action<string, string> handler = null) => Do(sub => sub.Subscribe(subChannel, (channel, message) =>
        {
            if (handler == null)
            {
                Console.WriteLine(subChannel + " Received Message：" + message);
            }
            else
            {
                handler(channel, message);
            }
        }));

        /// <summary>
        /// Redis发布订阅  发布
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="channel"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public long Publish(string channel, string msg) => Do(db => db.Publish(channel, msg));

        /// <summary>
        /// Redis发布订阅  取消订阅
        /// </summary>
        /// <param name="channel"></param>
        public void Unsubscribe(string channel) => Do(sub => sub.Unsubscribe(channel));

        /// <summary>
        /// Redis发布订阅  取消全部订阅
        /// </summary>
        public void UnsubscribeAll() => Do(sub => sub.UnsubscribeAll());


    }
}
