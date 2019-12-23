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
            if (context.User.Identity.IsAuthenticated)
            {
                var endpoint = context.Resource as Microsoft.AspNetCore.Routing.RouteEndpoint;
                var attrs = endpoint.Metadata.GetOrderedMetadata<PermissionCheckAttribute>();
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
