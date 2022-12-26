using PointCollector.Domain.Entities.Account;

namespace PointCollector.Application.Common.Interfaces.Persistence.Account
{
    public interface IAccountRepository
    {
        Task<PointCollector.Domain.Entities.Account.Account>? GetAccountByUserId(Guid userId);
        Task<PointCollector.Domain.Entities.Account.Account>? GetActiveAccountByUserId(Guid userId);
        Task<PointCollector.Domain.Entities.Account.Account> Add(PointCollector.Domain.Entities.Account.Account account);
    }
}
