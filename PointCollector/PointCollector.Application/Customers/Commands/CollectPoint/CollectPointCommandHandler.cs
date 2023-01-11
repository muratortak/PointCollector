using ErrorOr;
using MediatR;
using PointCollector.Application.Common.Interfaces.Persistence.Customers;
using PointCollector.Application.Customers.ViewModels;
using PointCollector.Domain.Common.Errors;
using PointCollector.Domain.Entities.Customers.Exceptions;

namespace PointCollector.Application.Customers.Commands.CollectPoint
{
    public class CollectPointCommandHandler : IRequestHandler<CollectPointCommand, ErrorOr<CollectPointViewModel>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPublisher _mediator;
        public CollectPointCommandHandler(IPublisher mediatr, IUserRepository userRepository)
        {
            _mediator = mediatr;
            _userRepository = userRepository;
        }
        public async Task<ErrorOr<CollectPointViewModel>> Handle(CollectPointCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = _userRepository.GetUserByEmail(request.UserEmail);
            
                if (user is null)
                {
                    return Errors.User.InvalidEmailOrPassword;
                }

                user.AddPoint(request.WorkspaceId, request.Points);
            
                foreach (var domainEvent in user.DomainEvents)
                {
                     _mediator.Publish(domainEvent).GetAwaiter().GetResult();
                }
                _userRepository.SaveChanges();
                return new CollectPointViewModel { UserFirstName = user.FirstName, CollectedPoint = request.Points, TotalPoint = user.GetTotalPoint() };
            }
            catch (PointMustBeGreaterThanEqualToZeroException ex)
            {
                return Errors.User.DuplicateEmail;
            }
        }
    }
}
