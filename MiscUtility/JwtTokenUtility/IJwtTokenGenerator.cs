using System;
using System.Collections.Generic;
using System.Text;

namespace MiscUtility.JwtTokenUtility
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(JwtTokenInfo tokenInfo,
                             string tokenIssuer = null,
                             string tokenAudience = null);
        string GenerateToken(JwtTokenInfo tokenInfo,
                             DateTime expiredTime,
                             string tokenIssuer = null,
                             string tokenAudience = null);
    }
}
