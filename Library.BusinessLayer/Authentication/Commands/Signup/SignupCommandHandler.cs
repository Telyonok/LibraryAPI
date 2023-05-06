using FluentValidation;
using Library.Application.Exceptions;
using Library.Application.Interfaces;
using Library.Domain.Helpers;
using Library.Domain.Models;
using MediatR;

namespace Library.Application.Authentication.Commands.Signup;
public class SignupCommandHandler : IRequestHandler<SignupCommand, AuthenticationResult>
{
    private readonly ILibraryDbContext _context;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IValidator<SignupCommand> _validator;

    public SignupCommandHandler(ILibraryDbContext context, IJwtTokenGenerator jwtTokenGenerator, IValidator<SignupCommand> validator)
    {
        _context = context;
        _validator = validator;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<AuthenticationResult> Handle(SignupCommand command, CancellationToken cancellationToken)
    {
        _validator.ValidateAndThrow(command);

        if (_context.Users.Any(u => u.Email == command.Email))
            throw new EntityAlreadyExistsException(string.Format(Constants.UserWithEmailExistsMessage, command.Email));

        var passwordHash = PasswordHasher.Hash(command.Password);
        var user = new User { Email = command.Email, PasswordHash = passwordHash };

        await _context.Users.AddAsync(user, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        var token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(user, token);
    }
}
