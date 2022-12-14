using PointCollector.Application.Common.Interfaces.Persistence;
using PointCollector.Domain.Entities.Customers.Rules;

namespace PointCollector.Application.Customers
{
    public class CustomerUniquenessChecker : ICustomerUniquenessChecker
    {
        private readonly IUserRepository _userRepository;
        public CustomerUniquenessChecker(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public bool IsUnique(string customerEmail)
        {
            return _userRepository.GetUserByEmail(customerEmail) is null;
        }
    }
}
