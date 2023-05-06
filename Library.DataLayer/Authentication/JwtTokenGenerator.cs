using Library.Application.Interfaces;
using Library.Domain.Models;
using Library.Infrastructure.Authentication.JwtBearerSettings;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Library.Infrastructure.Authentication;
public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly JwtBearerAuthenticationOptions _jwtSettings;

    public JwtTokenGenerator(IOptions<JwtBearerAuthenticationOptions> jwtOptions)
    {
        _jwtSettings = jwtOptions.Value;
    }

    public string GenerateToken(User user)
    {
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.JwtSigningKey)), SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email)
        };

        var securityToken = new JwtSecurityToken(
            issuer: _jwtSettings.ValidIssuer,
            audience: _jwtSettings.ValidAudience,
            expires: DateTime.UtcNow.AddMinutes(20),
            claims: claims,
            signingCredentials: signingCredentials
            );

        var token = new JwtSecurityTokenHandler().WriteToken(securityToken);

        return token;
    }
}
