using MediatR;
using PointCollector.Application.Common.Interfaces.Persistence.Account;
using PointCollector.Domain.Entities.Account.Rules;
using PointCollector.Domain.Entities.Customers.Events;
using PointCollector.Domain.Common;

namespace PointCollector.Application.Account.DomainEventHandlers
{
    public class UserRegisteredDomainEventHandler : INotificationHandler<UserRegisteredDomainEvent>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IAccountExistForCustomerChecker _accountExistForCustomerChecker;

        public UserRegisteredDomainEventHandler(IAccountRepository accountRepository, IAccountExistForCustomerChecker accountExistForCustomerChecker)
        {
            _accountRepository = accountRepository;
            _accountExistForCustomerChecker = accountExistForCustomerChecker;
        }

        public async Task Handle(UserRegisteredDomainEvent notification, CancellationToken cancellationToken)
        {
            var account = Domain.Entities.Account.Account.Create(notification.UserId, Globals.AccountStatus.Active, _accountExistForCustomerChecker);
            await _accountRepository.Add(account);
        }
    }
}
