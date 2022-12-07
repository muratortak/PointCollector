using PointCollector.Application.Common.Interfaces.Persistence;
using PointCollector.Domain.Entities.Customers;
using PointCollector.Infrastructure.Data;

namespace PointCollector.Infrastructure.Persistence
{
    public class UserRepository : IUserRepository
    {
        private readonly PointCollectorContext _context;
        private static readonly List<Customer> _users = new();
        public UserRepository(PointCollectorContext context)
        {
            _context = context;
        }
        public void Add(Customer user)
        {
            _context.Add(user);
            _context.SaveChanges();
        }

        public Customer? GetUserByEmail(string email)
        {
            return _context.Customers.SingleOrDefault(u => u.Email == email);
        }
    }
}
