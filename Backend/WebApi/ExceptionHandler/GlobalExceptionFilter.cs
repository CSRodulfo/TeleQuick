using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApi.ExceptionHandler
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var result = new CustomObjectResult(context.Exception);
            context.Result = result;

            Serilog.Log.Error(context.Exception, "GlobalExceptionFilter");
        }
    }
}
