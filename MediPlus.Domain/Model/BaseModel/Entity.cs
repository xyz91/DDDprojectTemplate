using System;
using System.Collections.Generic;
using System.Text;
using MediPlus.Domain.Event;
using MediPlus.Domain.Model.BaseModel;

namespace MediPlus.Domain.Model
{
   public abstract class Entity<K>:Obj,IEntity
    {
        protected Entity(K k)
        {
            this.Id = k;
        }
        public virtual K Id { get; protected set; }

        
    }
}
