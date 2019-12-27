using System;
using System.Collections.Generic;
using System.Text;
using MediPlus.Domain.Event;
using MediPlus.Domain.Model.BaseModel;

namespace MediPlus.Domain.Model
{
    /// <summary>
    /// 聚合根
    /// </summary>
    /// <typeparam name="K"></typeparam>
   public abstract class AggregateRoot<K> :Entity<K>,IAggregateRoot<K>
    {
        protected AggregateRoot(K k):base(k) {
           
        }
       
    }
}
