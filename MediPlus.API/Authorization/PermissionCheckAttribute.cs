using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediPlus.API
{
    public class PermissionCheckAttribute : AuthorizeAttribute
    {
        private new string Policy { get; set; }
        public PermissionCheckAttribute() : base("default") { }
        public int PowerId { get; set; }
    }
}
