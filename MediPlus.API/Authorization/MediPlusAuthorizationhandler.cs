using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace MediPlus.API
{
    public class MediPlusAuthorizationhandler : AuthorizationHandler<MediPlusRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MediPlusRequirement requirement)
        {
            //AuthorizationFilterContext filterContext = context.Resource as AuthorizationFilterContext;
            //HttpContext httpContext = accessor.HttpContext; 
            
            if (context.User.Identity.IsAuthenticated)
            {
                //ControllerActionDescriptor action = filterContext.ActionDescriptor as ControllerActionDescriptor;
                //object[] oooo = action.ControllerTypeInfo.GetCustomAttributes(typeof(PermissionCheckAttribute), true);
                //object[] oofw = action.MethodInfo.GetCustomAttributes(typeof(PermissionCheckAttribute), true);
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
