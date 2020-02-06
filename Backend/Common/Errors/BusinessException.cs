using System;

namespace Common.Errors
{
    public class BusinessException : Exception
    {
        public BusinessException(DetailError error)
        {
            this.Error = error;
        }

        public BusinessException(int code, string message)
        {
            this.Error = new DetailError(code, message);
        }

        public BusinessException(string code, string message)
        {
            this.Error = new DetailError(code, message);
        }

        public DetailError Error { get; set; }
    }
}
