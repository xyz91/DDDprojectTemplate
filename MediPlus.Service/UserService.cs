using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using MediPlus.Domain.IRepositories;
using MediPlus.Domain.Model;
using MediPlus.DTO;
using MediPlus.Service.Base;
using MediPlus.Service.Interface;
using System.Linq;
namespace MediPlus.Service
{
   public class UserService: BaseService<User,int,UserDTO>,IUserService
    {
        public UserService(IUserRepository userRepository):base(userRepository) {
            
        }

        public int Addrole(int id,RoleDTO role) {
          var o =  GetById(id);
          var oo =  o.Roles.Skip(1).Take(1);
           var rr = oo.ToList();
            repository.Load<Role>(o, t => t.Roles);
            // o.AddRole(Map<RoleDTO, Role>(role));
            //return  Update(o);
            return 3;
        }
    }
}
