using System;
using System.Collections.Generic;
using System.Text;

namespace MediPlus.Domain.Model
{
   public class MDBTest      : AggregateRoot<int>
    {
        public MDBTest(int id):base(id) { }
        public MDBTest(int id,string name):this(id) {
            this.Name = name;
        }
        public string Name { get; set; }
    }
}
