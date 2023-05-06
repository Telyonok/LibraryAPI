namespace Library.Web.Models;

public record AuthenticationResponse(
    string Email,
    string Token
);
