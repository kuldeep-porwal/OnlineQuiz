using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MiscUtility.JwtTokenUtility
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly SigningCredentials signingCredentials;
        private readonly JwtSecurityTokenHandler tokenHandler;
        public JwtTokenGenerator(JwtTokenConfig tokenConfig)
        {
            tokenHandler = new JwtSecurityTokenHandler();
            signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(tokenConfig.SecretKey)),
                                                        SecurityAlgorithms.HmacSha256Signature);
        }
        private SecurityTokenDescriptor GetSecurityTokenDescriptor(JwtTokenInfo tokenInfo,
                                                                   DateTime? expiredTime = null,
                                                                   string tokenIssuer = null,
                                                                   string tokenAudience = null)
        {
            return new SecurityTokenDescriptor
            {
                IssuedAt = DateTime.UtcNow,
                Subject = new ClaimsIdentity(GetClaims(tokenInfo)),
                SigningCredentials = signingCredentials,
                Expires = expiredTime,
                Issuer = tokenIssuer,
                Audience = tokenAudience
            };
        }

        private string CreateToken(SecurityTokenDescriptor tokenDescriptor)
        {
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private Claim[] GetClaims(JwtTokenInfo tokenInfo)
        {
            return new Claim[]
            {
                new Claim(ClaimTypes.Email, tokenInfo.Email),
                new Claim(ClaimTypes.Name, tokenInfo.UserName),
                new Claim(ClaimTypes.Role, tokenInfo.Role),
                new Claim(CustomClaimTypes.Id, tokenInfo.UserId.ToString())
            };
        }

        public string GenerateToken(JwtTokenInfo tokenInfo,
                                    string tokenIssuer = null,
                                    string tokenAudience = null)
        {
            return CreateToken(GetSecurityTokenDescriptor(tokenInfo, tokenIssuer: tokenIssuer, tokenAudience: tokenAudience));
        }

        public string GenerateToken(JwtTokenInfo tokenInfo,
                                    DateTime expiredTime,
                                    string tokenIssuer = null,
                                    string tokenAudience = null)
        {
            return CreateToken(GetSecurityTokenDescriptor(tokenInfo, expiredTime, tokenIssuer, tokenAudience));
        }
    }
}
