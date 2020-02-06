using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Errors
{
    public class IntegrationException : Exception
    {
        public IntegrationException(DetailError error)
        {
            this.Error = error;
        }

        public IntegrationException(int code, string message)
        {
            this.Error = new DetailError(code, message);
        }

        public DetailError Error { get; set; }
    }
}
