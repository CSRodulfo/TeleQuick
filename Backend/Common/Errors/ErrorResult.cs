using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Errors
{
    public class ErrorResult
    {
        public ErrorResult(DetailError error)
        {
            this.Error = error;
        }

        public DetailError Error { get; set; }
    }
}
