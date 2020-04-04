using System;
using System.Collections.Generic;
using System.Text;

namespace MiscUtility.JwtTokenUtility
{
    public interface IJwtToken
    {
        string GetToken(JwtTokenInfo tokenInfo);
    }
}
