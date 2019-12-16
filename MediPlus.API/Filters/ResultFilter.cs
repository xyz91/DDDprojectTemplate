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
            if (context.Result is ObjectResult) {
                ObjectResult obj = new ObjectResult(new { Success = true, Msg = "" });
                var objresult = context.Result as ObjectResult;
                if (!(objresult.Value is bool))
                {
                    obj = new ObjectResult(new { Success = true, Msg = "", Data = objresult.Value });
                }
                context.Result = obj;
            }          
            
        }
    }
}
