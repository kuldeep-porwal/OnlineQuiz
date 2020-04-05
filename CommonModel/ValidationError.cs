using System;
using System.Collections.Generic;
using System.Text;

namespace CommonModel
{
    public class ValidationError
    {
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public ValidationError(string errorMessage, int errorCode)
        {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
        }
    }
}
