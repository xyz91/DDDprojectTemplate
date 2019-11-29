using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace MediPlus.API.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context) {
            context.ExceptionHandled = true;
            context.Result = new ObjectResult(new { Success = true, Msg = context.Exception.Message});
            //context.HttpContext.Response.Body =new MemoryStream( Encoding.UTF8.GetBytes("test"));
        }
    }
}
