using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Commons
{
    public class BaseResponse
    {
        public BaseResponse(string errorCode = "", params string[] errors)
        {
            ErrorCode = errorCode;
            Errors = new List<string>(errors);
        }

        public string ErrorCode { get; set; }
        public List<string> Errors { get; set; }
    }
}
