using System;
using System.Collections.Generic;
using System.Text;
using MediPlus.Domain.Model;
using MediPlus.DTO;

namespace MediPlus.Service.Interface
{
  public  interface IUserService  : IBaseUnitService<User, int, UserDTO>
    {
        int Addrole(int id, RoleDTO role);
    }
}
