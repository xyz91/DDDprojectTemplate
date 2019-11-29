using System;
using System.Collections.Generic;
using System.Text;
using MediPlus.Domain.Model.BaseModel;

namespace MediPlus.Domain.Model
{
  public  class Role: AggregateRoot  <int>
    {
        protected Role(int id):base(id) { }
        public Role(int id,string name):this(id){
            this.Name = name;
        }
        public string Name { get; private set; }
        public int UserId { get; set; }
        public virtual User User { get; }

        
    }
}
