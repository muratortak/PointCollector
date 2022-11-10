using ErrorOr;
using MediatR;
using PointCollector.Application.Authentication.Common;
using PointCollector.Application.Common.Interfaces.Authentication;
using PointCollector.Application.Common.Interfaces.Persistence;
using PointCollector.Domain.Common.Errors;
using PointCollector.Domain.Entities;


namespace PointCollector.Application.Authentication.Queries.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;
        public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }
        public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
        {

            if (_userRepository.GetUserByEmail(query.email) is not User user)
            {
                return Errors.User.InvalidEmailOrPassword;
            }

            if (user.Password != query.password)
            {
                return Errors.User.InvalidEmailOrPassword;
            }

            var token = _jwtTokenGenerator.GenerateToken(user.Id, user.FirstName, user.LastName);

            return new AuthenticationResult(
                user.Id,
                user.FirstName,
                user.LastName,
                query.email,
                token);
        
        }
    }
}
