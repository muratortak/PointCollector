using PointCollector.Domain.Entities.Customers;

namespace PointCollector.Application.Common.Interfaces.Persistence.Customers
{
    public interface IUserRepository
    {
        Customer? GetUserByEmail(string email);
        Customer? GetUserById(Guid id);
        void Add(Customer user);
        void SaveChanges();
    }
}
