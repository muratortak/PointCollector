using ErrorOr;
using PointCollector.Application.Common.Interfaces.Authentication;
using PointCollector.Application.Common.Interfaces.Persistence;
using PointCollector.Domain.Common.Errors;
using PointCollector.Domain.Entities;

namespace PointCollector.Application.Services.Authentication;

public class AuthenticationService: IAuthenticationService 
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }
    public ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
    {
        if (_userRepository.GetUserByEmail(email) is not null) 
        {
            return Errors.User.DuplicateEmail;
        }

        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };

        _userRepository.Add(user);
        // Generat Token
        var userId = user.Id;
        var token = _jwtTokenGenerator.GenerateToken(userId, firstName, lastName);
        return new AuthenticationResult(
            userId,
            firstName,
            lastName,
            email,
            token);
    }
    public ErrorOr<AuthenticationResult> Login(string email, string password)
    {

        if (_userRepository.GetUserByEmail(email) is not User user)
        {
            return Errors.User.InvalidEmailOrPassword;
        }

        if(user.Password != password)
        {
            return Errors.User.InvalidEmailOrPassword;
        }

        var token = _jwtTokenGenerator.GenerateToken(user.Id, user.FirstName, user.LastName);

        return new AuthenticationResult(
            user.Id, 
            user.FirstName, 
            user.LastName, 
            email, 
            token);
    }
}