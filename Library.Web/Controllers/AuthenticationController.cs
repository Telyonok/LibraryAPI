using Library.Web.Filters;
using Microsoft.AspNetCore.Mvc;
using Library.DomainLayer.Models;
using Library.BusinessLayer.Interfaces;
using Library.BusinessLayer.Services.AuthenticationService;

namespace Library.Web.Controllers
{
    [ApiController]
    [Route("api/")]
    [UserExceptionHandlerFilter]
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
            Response.Cookies.Append(DomainLayer.Helpers.Constants.TokenKey, token.Value);
            return Ok("Successfull login.");
        }
    }
}
