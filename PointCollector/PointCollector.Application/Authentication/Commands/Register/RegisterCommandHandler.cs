using ErrorOr;
using MediatR;
using PointCollector.Application.Authentication.Common;
using PointCollector.Application.Common.Interfaces.Authentication;
using PointCollector.Application.Common.Interfaces.Persistence;
using PointCollector.Domain.Common.Errors;
using PointCollector.Domain.Entities.Customers;
using PointCollector.Domain.Entities.Customers.Rules;

namespace PointCollector.Application.Authentication.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;
        private readonly ICustomerUniquenessChecker _customerUniquenessChecker;
        public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository, ICustomerUniquenessChecker customerUniquenessChecker)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
            _customerUniquenessChecker = customerUniquenessChecker;
        }
        public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            //if (_userRepository.GetUserByEmail(command.email) is not null)
            //{
            //    return Errors.User.DuplicateEmail;
            //}

            var user = Customer.Create(command.firstName,command.lastName,command.email,command.password, _customerUniquenessChecker);

            _userRepository.Add(user);
            // Generate Token
            var token = _jwtTokenGenerator.GenerateToken(user);
            return new AuthenticationResult(
                user,
                token);
        }
    }
}
