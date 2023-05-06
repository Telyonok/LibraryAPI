using MediatR;
namespace Library.Application.Authentication.Commands.Signup;
public record SignupCommand(string Email, string Password) : IRequest<AuthenticationResult>;