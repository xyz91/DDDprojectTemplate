using System;
using System.Collections.Generic;
using System.Text;

namespace MediPlus.Domain.Event
{
    public interface IEventData
    {
        DateTime EventTime { get; set; }
         object EventSource { get; set; }
         EventType EventType { get; set; }
    }
    public enum EventType
    {
        AfterSave = 0,
        BeforeSave = 1,
        
    }
}
