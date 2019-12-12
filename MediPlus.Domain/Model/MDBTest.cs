using System;
using System.Collections.Generic;
using System.Text;
using MediPlus.Domain.Event;

namespace MediPlus.Domain.Model
{
   public class MDBTest      : AggregateRoot<int>
    {
       
        public MDBTest(int id):base(id) { }
        public MDBTest(int id,string name):this(id) {
            this.Name = name;
        }
        public string Name { get; set; }
        public void AddNode(ChildNode node) {
            this.Nodes.Add(node);
        }
        public ICollection<int> SIDs { get; set; }
        public ICollection<ChildNode> Nodes { get; set; }
    }

    public class ChildNode { 
        public string Name { get; set; }
        public int Type { get; set; }
    }

  
    
}
