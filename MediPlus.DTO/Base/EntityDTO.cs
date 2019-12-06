using System;
using System.Collections.Generic;
using System.Text;

namespace MediPlus.DTO
{
   public abstract class EntityDTO<K>: EntityDTOTag
    {
        public virtual K Id { get;  set; }
    }
    public abstract class EntityDTOTag { }
}
