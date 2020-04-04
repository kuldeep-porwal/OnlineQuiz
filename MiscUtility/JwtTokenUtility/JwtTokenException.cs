using System;
using System.Collections.Generic;
using System.Text;

namespace MiscUtility.JwtTokenUtility
{
    public class JwtTokenException : Exception
    {
        public JwtTokenException(string message) : base(message)
        {

        }
    }
}
