using PointCollector.Domain.Common.Interfaces;

namespace PointCollector.Domain.Entities.Account.Rules
{
    public class AccountMustNotExistForCustomerRule : IBusinessRule
    {
        private readonly IAccountExistForCustomerChecker _accountExistForCustomerChecker;
        private Guid _customerId;
        public AccountMustNotExistForCustomerRule(IAccountExistForCustomerChecker accountExistForCustomerChecker, Guid customerId)
        {
            _accountExistForCustomerChecker = accountExistForCustomerChecker;
            _customerId = customerId;
        }

        public bool IsBroken() => !_accountExistForCustomerChecker.IsExistForUser(_customerId).GetAwaiter().GetResult();
        public string Message => "User already has an active account.";
    }
}
