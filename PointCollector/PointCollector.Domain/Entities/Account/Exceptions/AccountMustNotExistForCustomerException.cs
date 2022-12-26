using PointCollector.Domain.Common.Exceptions;
using PointCollector.Domain.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointCollector.Domain.Entities.Account.Exceptions
{
    public class AccountMustNotExistForCustomerException : BusinessRuleValidationException
    {
        public AccountMustNotExistForCustomerException(IBusinessRule brokenRule) : base(brokenRule)
        {
        }
    }
}
