using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediPlus.Service.Interface;
using MediPlus.DTO;

namespace MediPlus.Web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : Controller
    {
       
        private IUserService userService;
        public UserController(IUserService userService) {
            this.userService = userService;
        }
        public int Get()
        {

        return    userService.Addrole(1, new RoleDTO() { Name = "22222测试2"});

           // var ss = userService.Select(a => a.ServiceType == typeof(IUUserService));
            var o = userService.GetDTOById(1);
            //return o;
            //return View();
        }
    }
}