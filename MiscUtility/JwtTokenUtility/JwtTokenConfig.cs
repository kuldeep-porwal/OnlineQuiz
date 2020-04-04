using System;
using System.Collections.Generic;
using System.Text;

namespace MiscUtility.JwtTokenUtility
{
    public class JwtTokenConfig
    {
        public string SecretKey { get; set; }
        public string Issuer { get; set; }
    }
}
