using Microsoft.EntityFrameworkCore;
using PointCollector.Application.Common.Interfaces.Persistence.Account;
using PointCollector.Domain.Entities.Account;
using PointCollector.Infrastructure.Data;
using static PointCollector.Domain.Common.Globals;

namespace PointCollector.Infrastructure.Persistence
{
    public class AccountRepository : IAccountRepository
    {
        private readonly PointCollectorContext _context;

        public AccountRepository(PointCollectorContext context)
        {
            _context = context;
        }
        public async Task<Account> Add(Account account)
        {
            await _context.AddAsync(account);
            await _context.SaveChangesAsync();

            return account;
        }

        public async Task<Account>? GetAccountByUserId(Guid userId)
        {
            return await _context.Accounts.SingleOrDefaultAsync(a => a.UserId == userId);
        }

        public async Task<Account>? GetActiveAccountByUserId(Guid userId)
        {
            return await _context.Accounts.SingleOrDefaultAsync(a => a.UserId == userId && a.AccountStatusId == (int)AccountStatus.Active);
        }
    }
}
