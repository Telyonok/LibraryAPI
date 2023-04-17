using Library.BusinessLayer.Interfaces;
using Library.DataLayer.Interfaces;
using Library.DomainLayer.Exceptions;
using Library.DomainLayer.Helpers;
using Library.DomainLayer.JwtBearerOptions;
using Library.DomainLayer.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Library.BusinessLayer.Services.AuthenticationService
{
    public class AuthenticationService : IAuthenticationService
    {
        private IUserRepository userRepository;
        private JwtBearerAuthenticationOptions authenticationOptions;
        public AuthenticationService(IUserRepository userRepository, IOptions<JwtBearerAuthenticationOptions> authenticationOptions)
        {
            this.userRepository = userRepository;
            this.authenticationOptions = authenticationOptions.Value;
        }
        public async Task<Token> GetTokenAsync(TokenRequest tokenRequest)
        {
            var user = await userRepository.GetUserAsync(tokenRequest.Email);
            if (user == null || user.Password != tokenRequest.Password) // Needs hashing.
            {
                throw new EntityNotFoundException(Constants.UserWrongCredentialsMessage);
            }
            return new Token() { Value = new JwtSecurityTokenHandler().WriteToken(GenerateToken(user)) };
        }

        private JwtSecurityToken GenerateToken(User user)
        {
            var claim = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, user.Email)
                };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationOptions.JwtSigningKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
                (
                issuer: authenticationOptions.ValidIssuer,
                audience: authenticationOptions.ValidAudience,
                claims: claim,
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: creds
                );
            return token;
        }
    }
}
