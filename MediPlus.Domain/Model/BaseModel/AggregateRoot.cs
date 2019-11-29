using System;
using System.Collections.Generic;
using System.Text;
using MediPlus.Domain.Model.BaseModel;

namespace MediPlus.Domain.Model
{
   public abstract class AggregateRoot<K> :Entity<K>,IAggregateRoot
    {
        protected AggregateRoot(K k):base(k) { }
    }
}
