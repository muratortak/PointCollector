using PointCollector.Application.Common.Interfaces.Persistence.Account;
using PointCollector.Domain.Entities.Account.Rules;

namespace PointCollector.Application.Account
{
    public class AccountExistForCustomerChecker : IAccountExistForCustomerChecker
    {
        private readonly IAccountRepository _accountRepository;
        public AccountExistForCustomerChecker(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task<bool> IsExistForUser(Guid customerId)
        {
            return await _accountRepository.GetActiveAccountByUserId(customerId) is null;
        }
    }
}
