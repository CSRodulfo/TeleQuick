using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Errors
{
    public class DetailError
    {
        public DetailError(string code, string message)
        {
            this.Code = code;
            this.Message = message;
        }

        public DetailError(int code, string message)
            : this(code.ToString(), message)
        {
        }

        public string Code { get; private set; }

        public string Message { get; private set; }
    }
}
