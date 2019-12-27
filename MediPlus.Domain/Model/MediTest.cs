using MediPlus.Domain.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediPlus.Domain.Model
{
   public class MediTest :AggregateRoot<string>
    {
        public MediTest(string id,string name):base(id) {
            this.Name = name;
        }
        public MediTest(string id,string name,IEnumerable<MediTestNode> mediTestNodes) :base(id) {
            this.Name = name;
            this.AddNode(mediTestNodes);
        }
        public string Name { get; private set; }
        private   List<MediTestNode> _mediTestNodes = new List<MediTestNode>();
        public virtual IEnumerable<MediTestNode> MediTestNodes => _mediTestNodes.ToList();
        public void AddNode(IEnumerable<MediTestNode> nodes) {
            _mediTestNodes.AddRange(nodes);
            AddEvent(new MediTestAddNodeEventData()
            {
                MediTestNodes = nodes,
                MediTest = this,
            });
        }
        
    }
}
