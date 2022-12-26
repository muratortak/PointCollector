using MediatR;

namespace PointCollector.Domain.Entities.Customers.Events
{
    public class UserRegisteredDomainEvent : INotification
    {
        public Guid UserId { get; set; }

        public UserRegisteredDomainEvent(Guid userId)
        {
            UserId = userId;
        }
    }
}
