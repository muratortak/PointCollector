using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointCollector.Domain.Entities.Account.Rules
{
    public interface IAccountExistForCustomerChecker
    {
        Task<bool> IsExistForUser(Guid customerId);
    }
}
