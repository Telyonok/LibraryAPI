using Microsoft.AspNetCore.Mvc;
using Library.Domain.Helpers;
using Library.Application.Authentication.Queries.Login;
using MediatR;
using Library.Application.Authentication.Commands.Signup;

namespace Library.Web.Controllers
{
    [ApiController]
    [Route("api/")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthenticationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("Login/")]
        public async Task<IActionResult> LoginAsync(LoginQuery query)
        {
            var result = await _mediator.Send(query);
            Response.Cookies.Append(Constants.TokenKey, result.Token);
            return Ok(result);
        }

        [HttpPost]
        [Route("Signup/")]
        public async Task<IActionResult> SignupAsync(SignupCommand command)
        {
            var result = await _mediator.Send(command);
            Response.Cookies.Append(Constants.TokenKey, result.Token);
            return Ok(result);
        }
    }
}
