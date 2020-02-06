using Common.Errors;
using DataAccess.Commons;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;

namespace WebApi.ExceptionHandler
{
    public class ErrorResponse
    {
        public ErrorResponse(Exception exception)
        {
            if (exception is BusinessException businessException)
            {
                this.Message = businessException.Error.Message;
            }
            else if (exception is ClientException clientException)
            {
                this.Message = clientException.ClientMessageException;
                this.Code = clientException.ClientCodeException;
            }
            else
            {
                this.Message = "Se ha producido un error, por favor reintente en unos minutos";
            }
        }

        public string Message { get; private set; }
        public string Code { get; private set; }
    }
}