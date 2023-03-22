﻿using Library.Domain.Abstractions;
using Library.Domain.Exceptions;
using Library.Domain.Helpers;
using Library.Domain.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLL.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private IUserRepository userRepository;
        private CryptoSettings cryptoSettings;
        public AuthenticationService(IUserRepository userRepository, IOptions<CryptoSettings> cryptoSettings)
        {
            this.userRepository = userRepository;
            this.cryptoSettings = cryptoSettings.Value;
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
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(cryptoSettings.JwtSigningKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
                (
                issuer: "localhost:5190",
                audience: "localhost:5190",
                claims: claim,
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: creds
                );
            return token;
        }
    }
}
