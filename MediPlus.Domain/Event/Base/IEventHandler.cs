using System;
using System.Collections.Generic;
using System.Text;

namespace MediPlus.Domain.Event
{
 
    public abstract class BaseEventHandler< D>:IEventHandler  where D:class,IEventData
    {
       public abstract void HandleEvent(D eventData);
        public void HandleEvent(IEventData eventData) {
            HandleEvent(eventData as D);
        }
    }

    public interface IEventHandler
    {
       public void HandleEvent(IEventData eventData);
    }



}
