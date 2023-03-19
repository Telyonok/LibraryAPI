using Library.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Abstractions
{
    public interface IAuthenticationService
    {
        Task<Token> GetTokenAsync(TokenRequest tokenRequest);
    }
}
