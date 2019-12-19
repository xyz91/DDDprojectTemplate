using System;
using System.Collections.Generic;
using System.Text;

namespace MediPlus.Domain.Event
{
 
    public abstract class BaseEventHandler<D>:IEventHandler  where D:class,IEventData
    {
       public abstract void HandleEvent(D eventData);
        public abstract void OnError(D eventData,Exception e);
        public void HandleEvent(IEventData eventData) {
            HandleEvent(eventData as D);
        }
        public void OnError(IEventData eventData, Exception e) {
            OnError(eventData as D, e);
        }
    }

    public interface IEventHandler
    {
        void HandleEvent(IEventData eventData);
        void OnError(IEventData eventData, Exception e);
    }



}
