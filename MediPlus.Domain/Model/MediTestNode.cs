using System;
using System.Collections.Generic;
using System.Text;

namespace MediPlus.Domain.Model
{
   public  class MediTestNode :Entity<int>
    {
        public MediTestNode(int id):base(id) { }
        public string Name { get; set; }
        public string MediTestId { get; set; }
        public virtual MediTest MediTest { get; set; }
    }
}
