using Library.DomainLayer.Models;
using Library.BusinessLayer.Services.AuthenticationService;

namespace Library.BusinessLayer.Interfaces
{
    public interface IAuthenticationService
    {
        Task<Token> GetTokenAsync(TokenRequest tokenRequest);
    }
}
