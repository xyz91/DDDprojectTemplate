using System;
using System.Collections.Generic;
using System.Text;
using MediPlus.Domain.Event;
using MediPlus.Domain.Model.BaseModel;

namespace MediPlus.Domain.Model
{
   public abstract class Entity: IEntity
    {
        private List<IEventData> _events;
        public IReadOnlyCollection<IEventData> EventDatas => _events?.AsReadOnly();
        public void AddEvent(IEventData eventData)
        {
            _events = _events ?? new List<IEventData>();
            _events.Add(eventData);
        }
        public void ClearEvents()
        {
            _events?.Clear();
        }
        public void RemoveEvent(IEventData eventData)
        {
            _events?.Remove(eventData);
        }
    }
}
