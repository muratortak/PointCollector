using PointCollector.Domain.Entities.Customers;

namespace PointCollector.Application.Common.Interfaces.Persistence
{
    public interface IUserRepository
    {
        Customer? GetUserByEmail(string email);
        void Add(Customer user);
    }
}
