using System;
using System.Collections.Generic;
using System.Text;

namespace MediPlus.DTO
{
   public class MediTestNodeDTO :EntityDTO<int>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public virtual MediTestDTO MediTest { get; set; }
    }
}
