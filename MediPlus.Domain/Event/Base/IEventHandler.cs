using System;
using System.Collections.Generic;
using System.Text;

namespace MediPlus.Domain.Event
{
 
    public abstract class BaseEventHandler<D>:IEventHandler  where D:class,IEventData
    {
        /// <summary>
        /// 事件处理
        /// </summary>
        /// <param name="eventData">事件参数</param>
       public abstract void HandleEvent(D eventData);
        /// <summary>
        /// 出错后处理
        /// </summary>
        /// <param name="eventData">事件参数</param>
        /// <param name="e">错误exception</param>
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
        /// <summary>
        /// 事件处理
        /// </summary>
        /// <param name="eventData">事件参数</param>
        void HandleEvent(IEventData eventData);
        /// <summary>
        /// 出错后处理
        /// </summary>
        /// <param name="eventData">事件参数</param>
        /// <param name="e">错误exception</param>
        void OnError(IEventData eventData, Exception e);
    }



}
