using System;
using System.Collections.Generic;
using System.Text;

namespace MediPlus.Domain.Event
{
    public class EventData : IEventData

    {
        protected EventData(EventType eventType) {
            this.EventType = eventType;
        }
        public DateTime EventTime { get; set; } = DateTime.Now;
        public object EventSource { get; set; }
        public EventType EventType { get; set; }
    }
}
