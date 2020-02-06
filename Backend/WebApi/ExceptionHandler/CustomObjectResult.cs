using DataAccess.Commons;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace WebApi.ExceptionHandler
{
    public class CustomObjectResult : ObjectResult
    {
        public CustomObjectResult(Exception value) : base(new ErrorResponse(value))
        {
            if (value is Common.Errors.BusinessException)
            {
                this.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else if (value is ClientException clientException)
            {
                this.StatusCode = (int)clientException.CodeException;
            }
            else
            {
                this.StatusCode = (int)HttpStatusCode.InternalServerError;
            }

            this.DeclaredType = typeof(ErrorResponse);
        }


    }
}
