using System;
using System.Collections.Generic;
using System.Text;

namespace MediPlus.Domain.Event
{
    public class EventData : IEventData

    {
        public DateTime EventTime { get; set; } = DateTime.Now;
        public object EventSource { get; set; }
        public EventType EventType { get; set; }
    }
}
