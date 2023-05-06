using FluentValidation;
using Library.Application.Exceptions;
using Library.Application.Interfaces;
using Library.Domain.Helpers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Authentication.Queries.Login;
public class LoginQueryHandler : IRequestHandler<LoginQuery, AuthenticationResult>
{
    private readonly ILibraryDbContext _context;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IValidator<LoginQuery> _validator;

    public LoginQueryHandler(ILibraryDbContext context, IJwtTokenGenerator jwtTokenGenerator, IValidator<LoginQuery> validator)
    {
        _context = context;
        _validator = validator;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<AuthenticationResult> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        _validator.ValidateAndThrow(query);

        var user = await _context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Email == query.Email);
        var passwordHash = PasswordHasher.Hash(query.Password);
        if (user is null || passwordHash != user.PasswordHash)
            throw new EntityNotFoundException(Constants.UserWrongCredentialsMessage);

        var token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(user, token);
    }
}

