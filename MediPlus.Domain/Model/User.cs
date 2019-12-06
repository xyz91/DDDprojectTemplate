using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MediPlus.Domain.Model.BaseModel;

namespace MediPlus.Domain.Model
{
  public  class User: AggregateRoot<int>
    {
        protected User(int id) :base(id){ 
        
        }
        public User(int id,string name,int age):this(id) {
            this.Name = name;
        }
        public string Name { get;private set; }


        public virtual ICollection<Role> Roles { get; set; }
                                 
        public void AddRole(Role role) {
            this.Roles = new[] { role };                     
        }
        public bool RemoveRole(Role role) {
           return  this.Roles.Remove(role);
        }
    }
}
