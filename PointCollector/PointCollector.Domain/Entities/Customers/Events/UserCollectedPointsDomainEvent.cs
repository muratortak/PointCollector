using MediatR;

namespace PointCollector.Domain.Entities.Customers.Events
{
    public class UserCollectedPointsDomainEvent : INotification
    {
        public Guid UserId { get; set; }
        public UserCollectedPointsDomainEvent(Guid userId)
        {
            UserId = userId;
        }
    }
}
