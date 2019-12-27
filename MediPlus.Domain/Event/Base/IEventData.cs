using System;
using System.Collections.Generic;
using System.Text;

namespace MediPlus.Domain.Event
{
    public interface IEventData
    {
        /// <summary>
        /// 事件时间
        /// </summary>
        DateTime EventTime { get; set; }
        /// <summary>
        /// 引发事件的源
        /// </summary>
         object EventSource { get; set; }
        /// <summary>
        /// 事件类型
        /// </summary>
         EventType EventType { get; set; }
    }
    public enum EventType
    {
        AfterSave = 0,
        BeforeSave = 1,
        
    }
}
