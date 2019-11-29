using System;
using System.Collections.Generic;
using System.Text;

namespace MediPlus.DTO
{
   public abstract class EntityDTO<K>
    {
        public virtual K Id { get; protected set; }
    }
}
