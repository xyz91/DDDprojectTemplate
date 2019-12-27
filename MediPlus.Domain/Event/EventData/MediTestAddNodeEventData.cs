using MediPlus.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediPlus.Domain.Event
{
    public class MediTestAddNodeEventData : EventData
    {
        public IEnumerable<MediTestNode> MediTestNodes { get; set; }
        public MediTest MediTest { get; set; }
    }
}
