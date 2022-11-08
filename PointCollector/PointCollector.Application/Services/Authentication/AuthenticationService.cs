using PointCollector.Application.Common.Interfaces.Authentication;
using PointCollector.Application.Common.Interfaces.Persistence;
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
    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        if (_userRepository.GetUserByEmail(email) is not null) 
        {
            throw new Exception("User already exists.");
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
    public AuthenticationResult Login(string email, string password)
    {

        if (_userRepository.GetUserByEmail(email) is not User user)
        {
            throw new Exception("Invalid email/password.");
        }

        if(user.Password != password)
        {
            throw new Exception("Invalid email/password.");
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