using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MediPlus.API.Filters
{
    public class ResourceFilter : IResourceFilter
    {
        public void OnResourceExecuted(ResourceExecutedContext context) { }
        public void OnResourceExecuting(ResourceExecutingContext context) { }
    }
}
