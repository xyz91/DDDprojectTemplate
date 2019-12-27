using MediPlus.Domain.Event;
using MediPlus.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace MediPlus.Service.events
{
    public class AddNodeHandler : BaseEventHandler<MediTestAddNodeEventData>
    {
        private IMediTestRedisRepository redisRepository;
        public AddNodeHandler(IMediTestRedisRepository redisRepository) {
            this.redisRepository = redisRepository;
        }
        public override void HandleEvent(MediTestAddNodeEventData eventData) {
            
            redisRepository.StringSet( eventData.MediTest.Id,JsonConvert.SerializeObject(eventData.MediTest,new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore}));
            Console.WriteLine(redisRepository.StringGet(eventData.MediTest.Id));
        }
        public override void OnError(MediTestAddNodeEventData eventData, Exception e) => Console.WriteLine(e.Message);
    }
}
