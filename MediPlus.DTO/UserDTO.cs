using System;
using System.Collections.Generic;
using System.Text;

namespace MediPlus.DTO
{
   public class UserDTO : EntityDTO<int>
    {
        public string Name { get; private set; }

        //public virtual ICollection<RoleDTO> Roles { get; set; }
   
    }
}
