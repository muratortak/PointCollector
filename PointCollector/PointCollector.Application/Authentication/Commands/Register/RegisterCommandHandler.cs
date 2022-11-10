using ErrorOr;
using MediatR;
using PointCollector.Application.Authentication.Common;
using PointCollector.Application.Common.Interfaces.Authentication;
using PointCollector.Application.Common.Interfaces.Persistence;
using PointCollector.Domain.Common.Errors;
using PointCollector.Domain.Entities;


namespace PointCollector.Application.Authentication.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;
        public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }
        public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            if (_userRepository.GetUserByEmail(command.email) is not null)
            {
                return Errors.User.DuplicateEmail;
            }

            var user = new User
            {
                FirstName = command.firstName,
                LastName = command.lastName,
                Email = command.email,
                Password = command.password
            };

            _userRepository.Add(user);
            // Generat Token
            var userId = user.Id;
            var token = _jwtTokenGenerator.GenerateToken(userId, command.firstName, command.lastName);
            return new AuthenticationResult(
                userId,
                command.firstName,
                command.lastName,
                command.email,
                token);
        }
    }
}
