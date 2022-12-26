using ErrorOr;
using MediatR;
using PointCollector.Application.Authentication.Common;
using PointCollector.Application.Common.Interfaces.Authentication;
using PointCollector.Application.Common.Interfaces.Persistence.Customers;
using PointCollector.Domain.Common.Errors;
using PointCollector.Domain.Entities.Customers;
using PointCollector.Domain.Entities.Customers.Exceptions;
using PointCollector.Domain.Entities.Customers.Rules;

namespace PointCollector.Application.Authentication.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;
        private readonly ICustomerUniquenessChecker _customerUniquenessChecker;
        private readonly IPublisher _mediator;
        public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository, ICustomerUniquenessChecker customerUniquenessChecker, IPublisher mediator)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
            _customerUniquenessChecker = customerUniquenessChecker;
            _mediator = mediator;
        }
        public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var user = Customer.Create(command.firstName,command.lastName,command.email,command.password, _customerUniquenessChecker);

                _userRepository.Add(user);
                foreach (var domainEvent in user.DomainEvents)
                {
                    await _mediator.Publish(domainEvent);
                }
                // Generate Token
                var token = _jwtTokenGenerator.GenerateToken(user);
                return new AuthenticationResult(
                    user,
                    token);
            }
            catch(CustomerEmailMustBeUniqueException ex)
            {
                return Errors.User.DuplicateEmail;
            }
        }
    }
}
