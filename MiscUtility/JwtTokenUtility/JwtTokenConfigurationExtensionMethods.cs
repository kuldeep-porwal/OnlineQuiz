using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace MiscUtility.JwtTokenUtility
{
    public static class JwtTokenConfigurationExtensionMethods
    {
        public static void AddJwtTokenService(this IServiceCollection serviceCollection, JwtTokenConfig jwtTokenConfig)
        {
            serviceCollection.AddSingleton(jwtTokenConfig);
            serviceCollection.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
            serviceCollection
                .AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.TokenValidationParameters = new TokenValidationParameters()
                    {
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtTokenConfig.SecretKey))
                    };
                });
        }
    }
}
