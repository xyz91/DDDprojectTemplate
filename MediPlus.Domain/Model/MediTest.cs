using MediPlus.Domain.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediPlus.Domain.Model
{
   public class MediTest :AggregateRoot<string>
    {
        public MediTest(string id):base(id) { }
        public string Name { get; set; }
        private List<MediTestNode> _mediTestNodes = new List<MediTestNode>();
        public virtual List<MediTestNode> MediTestNodes {
            get { return _mediTestNodes; }
            private set { _mediTestNodes = value; }
        }
        public void AddNode(params MediTestNode[] nodes) {
            _mediTestNodes.AddRange(nodes);
            AddEvent(new MediTestAddNodeEventData()
            {
                MediTestNodes = nodes,
                MediTest = this,
            });
        }
        
    }
}
