using System;
using System.Collections.Generic;
using System.Text;
using MediPlus.Domain.Event;

namespace MediPlus.Domain.Model.BaseModel
{
    /// <summary>
    /// 对象基类
    /// </summary>
   public abstract class Obj
    {
        private List<IEventData> _events;
        /// <summary>
        /// 事件集合
        /// </summary>
        [Newtonsoft.Json.JsonIgnore]
        public IReadOnlyCollection<IEventData> EventDatas => _events?.AsReadOnly();
        /// <summary>
        /// 添加事件
        /// </summary>
        /// <param name="eventData"></param>
        protected void AddEvent(IEventData eventData)
        {
            _events = _events ?? new List<IEventData>();
            _events.Add(eventData);
        }
        /// <summary>
        /// 清空事件
        /// </summary>
        public void ClearEvents()
        {
            _events?.Clear();
        }
        /// <summary>
        /// 删除事件
        /// </summary>
        /// <param name="eventData"></param>
        protected void RemoveEvent(IEventData eventData)
        {
            _events?.Remove(eventData);
        }
    }
}
