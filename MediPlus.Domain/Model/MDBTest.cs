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
        public IEnumerable<int> SIDs { get; set; }
        public IEnumerable<ChildNode> Nodes { get; set; }
    }

    public class ChildNode { 
        public string Name { get; set; }
        public int Type { get; set; }
    }

  
    
}
