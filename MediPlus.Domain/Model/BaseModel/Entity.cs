﻿using System;
using System.Collections.Generic;
using System.Text;
using MediPlus.Domain.Model.BaseModel;

namespace MediPlus.Domain.Model
{
   public abstract class Entity<K>:IEntity
    {
        protected Entity(K id) {
            this.Id = id;
        }
        public virtual K Id { get; protected set; }
    }
}