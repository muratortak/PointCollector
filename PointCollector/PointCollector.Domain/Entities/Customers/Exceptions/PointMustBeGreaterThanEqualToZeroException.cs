using PointCollector.Domain.Common.Exceptions;
using PointCollector.Domain.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointCollector.Domain.Entities.Customers.Exceptions
{
    public class PointMustBeGreaterThanEqualToZeroException : BusinessRuleValidationException
    {
        public PointMustBeGreaterThanEqualToZeroException(IBusinessRule brokenRule) : base(brokenRule)
        {
        }

    }
}
