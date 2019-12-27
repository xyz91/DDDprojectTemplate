using System;
using System.Collections.Generic;
using System.Text;

namespace MediPlus.Domain.Model
{
   public  class MediTestNode : AggregateRoot<int>
    {
        public MediTestNode(int id,string name):base(id) {
            //throw new Exception("node名称不正确");
            this.Name = name;
        }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string MediTestId { get; private set; }
        private MediTest _mediTest = null;
        public virtual MediTest MediTest {
            get { return _mediTest; }
            set { _mediTest = value; }
        }
    }
}
