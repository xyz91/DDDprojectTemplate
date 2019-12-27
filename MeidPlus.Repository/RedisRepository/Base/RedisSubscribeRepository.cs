using System;

namespace MeidPlus.Repository.RedisRepository
{
    public partial class RedisBaseRepository
    {
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
        public long Publish(string channel, string msg) => Do(db => db.Publish(channel, msg));
        public void Unsubscribe(string channel) => Do(sub => sub.Unsubscribe(channel));
        public void UnsubscribeAll() => Do(sub => sub.UnsubscribeAll());


    }
}
