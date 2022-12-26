using PointCollector.Domain.Common.Interfaces;
using PointCollector.Domain.Common.Models;
using PointCollector.Domain.Entities.Account.Exceptions;
using PointCollector.Domain.Entities.Account.Rules;
using PointCollector.Domain.Entities.Account.ValueObjects;
using static PointCollector.Domain.Common.Globals;

namespace PointCollector.Domain.Entities.Account
{
    public class Account : Entity<AccountId>, IAggregateRoot
    {
        private Account()
        {

        }

        private Account(Guid userId, AccountStatus accountStatus) : base(AccountId.Create())
        {
            Id = base.Id;
            UserId = userId;
            AccountStatusId = (int)accountStatus;
            CreatedAt = DateTime.UtcNow;
        }

        public static Account Create(Guid userId, AccountStatus accountStatus, IAccountExistForCustomerChecker accountExistForCustomerChecker)
        {

            CheckRule(new AccountMustNotExistForCustomerRule(accountExistForCustomerChecker, userId), typeof(AccountMustNotExistForCustomerException));
            return new Account(userId, accountStatus);
        }

        public AccountId Id { get; set; }
        public int AccountStatusId { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
