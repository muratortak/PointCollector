using ErrorOr;
using MediatR;
using PointCollector.Application.Account.Models;
using PointCollector.Application.Common.Interfaces.Persistence.Account;
using PointCollector.Domain.Common.Errors;
using PointCollector.Domain.Entities.Account.Exceptions;
using PointCollector.Domain.Entities.Account.Rules;
using static PointCollector.Domain.Common.Globals;

namespace PointCollector.Application.Account.Commands.Create
{
    public class AccountCreateCommandHandler
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IAccountExistForCustomerChecker _accountExistForCustomerChecker;

        public AccountCreateCommandHandler(IAccountRepository accountRepository, IAccountExistForCustomerChecker accountExistForCustomerChecker)
        {
            _accountRepository = accountRepository;
            _accountExistForCustomerChecker = accountExistForCustomerChecker;
        }

        public async Task<ErrorOr<AccountModel>> Handle(AccountCreateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var account = PointCollector.Domain.Entities.Account.Account.Create(request.UserId, request.AccountStatus, _accountExistForCustomerChecker);
                await _accountRepository.Add(account);

                return new AccountModel { Id = account.Id.Id, Status = (AccountStatus)account.AccountStatusId };
            }
            catch (AccountMustNotExistForCustomerException ex)
            {
                return Errors.Workspace.DuplicateName;
            }
        }

    }
}
