using Library.Domain.Models;

namespace Library.Application.Interfaces;
public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}
