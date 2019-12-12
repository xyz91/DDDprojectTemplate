using System;
using System.Collections.Generic;
using System.Text;

namespace MediPlus.Domain.Event
{
    public interface IEventData
    {
       public DateTime EventTime { get; set; }
        public object EventSource { get; set; }
        public EventType EventType { get; set; }
    }
    public enum EventType
    {
        AfterSave = 0,
        BeforeSave = 1,
        
    }
}
