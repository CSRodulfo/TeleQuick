using System;
using System.Net;

namespace DataAccess.Commons
{
    public class ClientException : ArgumentException
    {
 
        public ClientException(HttpStatusCode codeException, string messageException, string clientCode = null)
        {
            this.ClientMessageException = messageException;
            this.ClientCodeException = clientCode;
            this.CodeException = codeException;
        }
 
        public string ClientMessageException { get; set; }

        public string ClientCodeException { get; set; }
        public HttpStatusCode CodeException { get; set; }
    }
}