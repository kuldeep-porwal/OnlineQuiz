using CommonModel;
using MiscUtility.JwtTokenUtility;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserBiz.Model;

namespace UserBiz
{
    public class LoginManager : ILoginManager
    {
        private readonly IJwtTokenGenerator jwtTokenGenerator;

        public LoginManager(IJwtTokenGenerator jwtTokenGenerator)
        {
            this.jwtTokenGenerator = jwtTokenGenerator;
        }
        public async Task<LoginResponse> Login(LoginRequest loginRequest)
        {
            LoginResponse loginResponse = new LoginResponse();

            if (loginRequest == null)
            {
                loginResponse = GetValidationResponse("LoginRequest cant't be null", 1001);
                return loginResponse;
            }

            loginResponse.StatusCode = 200;
            loginResponse.TokenDetail = GetToken(loginRequest);

            return await Task.FromResult(loginResponse);

        }
        private LoginResponse GetValidationResponse(string errorMessage, int errorCode)
        {
            return GetValidationResponse(new ValidationError(errorMessage, errorCode));
        }
        private LoginResponse GetValidationResponse(ValidationError validationError)
        {
            return new LoginResponse()
            {
                Errors = new List<ValidationError>()
                {
                    validationError
                },
                StatusCode = 400
            };
        }

        private TokenInfo GetToken(LoginRequest loginRequest)
        {
            var tokenInfo = new TokenInfo();
            tokenInfo.TokenType = "Bearer";
            tokenInfo.Token = jwtTokenGenerator.GenerateToken(new JwtTokenInfo()
            {
                Email = loginRequest.Email,
                UserName = loginRequest.Email,
                Role = "Admin",
                UserId = 1
            });
            return tokenInfo;
        }
    }
}
