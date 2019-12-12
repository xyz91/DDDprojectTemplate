using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MediPlus.Domain.Event;
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

        private ICollection<Role> _roles = new List<Role>();

        public virtual ICollection<Role> Roles => _roles;
                                 
        public void AddRole(Role role) {
            _roles.Add(role);
            //this.Name = "2222";
            AddEvent(new MDBTestAddEventData(this));
        }
        public bool RemoveRole(Role role) {
            return _roles.Remove(role);
        }
        public void ChangeName(string name) {
            this.Name = name;
        }
    }
}
