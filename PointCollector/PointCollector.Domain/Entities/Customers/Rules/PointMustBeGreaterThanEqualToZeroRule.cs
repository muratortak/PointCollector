using PointCollector.Domain.Common.Interfaces;

namespace PointCollector.Domain.Entities.Customers.Rules
{
    public class PointMustBeGreaterThanEqualToZeroRule : IBusinessRule
    {
        private decimal _point;
        public PointMustBeGreaterThanEqualToZeroRule(decimal point)
        {
            _point = point;
        }
        public string Message => "Point cannot be less than zero.";

        public bool IsBroken() => _point < decimal.Zero;
    }
}
