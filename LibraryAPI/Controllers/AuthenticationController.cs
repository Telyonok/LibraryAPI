using Library.Domain.Abstractions;
using Library.Domain.Models;
using LibraryAPI.Filters;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [ApiController]
    [Route("api/")]
    [AuthenticationExceptionHandlerFilter]
    public class AuthenticationController : ControllerBase
    {
        IAuthenticationService authenticationService;
        public AuthenticationController(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;    
        }

        [HttpPost]
        [Route("Login/")]
        public async Task<IActionResult> LoginAsync(TokenRequest tokenRequest)
        {
            // Call AuthenticationService instead.
            Token token = await authenticationService.GetTokenAsync(tokenRequest);
            Response.Cookies.Append(Library.Domain.Helpers.Constants.TokenKey, token.Value);
            return Ok("Successfull login.");
        }
    }
}
