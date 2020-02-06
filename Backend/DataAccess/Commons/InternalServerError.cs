using System;
namespace DataAccess.Commons
{
    public class InternalServerError
    {
        public InternalServerError()
        {
        }

        public string Code { get; set; }

        public string Message { get; set; }
    }
}
