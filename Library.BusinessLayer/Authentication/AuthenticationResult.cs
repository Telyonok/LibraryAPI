using Library.Domain.Models;

namespace Library.Application.Authentication;
public record AuthenticationResult(User User, string Token);
