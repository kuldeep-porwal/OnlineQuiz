using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MiscUtility.JwtTokenUtility
{
    public class JwtToken : IJwtToken
    {
        private readonly IJwtTokenGenerator jwtTokenGenerator;

        public JwtToken(IJwtTokenGenerator jwtTokenGenerator)
        {
            this.jwtTokenGenerator = jwtTokenGenerator;
        }

        public string GetToken(JwtTokenInfo tokenInfo)
        {
            if (tokenInfo == null)
            {
                throw new JwtTokenException("JwtTokenInfo can't be null");
            }

            return jwtTokenGenerator.GenerateToken(tokenInfo);
        }
    }
}
