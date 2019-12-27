using System;
using System.Collections.Generic;
using System.Text;
using MediPlus.Domain.Event;
using MediPlus.Domain.Model.BaseModel;

namespace MediPlus.Domain.Model
{
    /// <summary>
    /// 实体根
    /// </summary>
    /// <typeparam name="K"></typeparam>
   public abstract class Entity<K>:Obj,IEntity 
    {
        protected Entity(K k)
        {
            this.Id = k;
        }
        public  K Id { get; private set; }

        
    }
}
