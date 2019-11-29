using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MediPlus.API.Filters
{
    public class ResultFilter : IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext context) { 
        
        }
        public void OnResultExecuting(ResultExecutingContext context) {
            var  obj = new ObjectResult(new { Success = true, Msg = "", Data = (context.Result as ObjectResult).Value });
            context.Result = obj; 
        }
    }
}
