using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;

namespace Library.Infrastructure.Authentication.JwtBearerSettings
{
    public class JwtBearerAuthenticationConfigurator : IConfigureNamedOptions<JwtBearerOptions>
    {
        private readonly JwtBearerAuthenticationOptions options;
        public JwtBearerAuthenticationConfigurator(IOptions<JwtBearerAuthenticationOptions> authenticationOptions)
        {
            options = authenticationOptions.Value;
        }

        public void Configure(string? name, JwtBearerOptions bearerOptions)
        {
            Configure(bearerOptions);
        }

        public void Configure(JwtBearerOptions bearerOptions)
        {
            bearerOptions.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = options.ValidateIssuer,
                ValidateAudience = options.ValidateAudience,
                ValidateLifetime = options.ValidateLifetime,
                ValidateIssuerSigningKey = options.ValidateIssuerSigningKey,
                ValidIssuer = options.ValidIssuer,
                ValidAudience = options.ValidAudience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.JwtSigningKey)),
                ClockSkew = TimeSpan.FromSeconds(options.ClockSkewSeconds)
            };
        }
    }
}
