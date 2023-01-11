using Microsoft.EntityFrameworkCore;
using PointCollector.Application.Common.Interfaces.Persistence.Customers;
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
            try
            {
                var us = _context.Customers.Where(u => u.Email == email);
                return us.FirstOrDefault();
            }
            catch(Exception ex)
            {
                return null;
            }
            
        }

        public Customer? GetUserById(Guid id)
        {
            var us = _context.Customers.ToList();
            return us.SingleOrDefault(u => u.Id == id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
