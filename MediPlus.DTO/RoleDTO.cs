using System;
using System.Collections.Generic;
using System.Text;

namespace MediPlus.DTO
{
  public  class RoleDTO: EntityDTO<int>
    {
        public string Name { get; private set; }
        public int UserId { get; set; }
        public virtual UserDTO User { get; set; }
    }
}
