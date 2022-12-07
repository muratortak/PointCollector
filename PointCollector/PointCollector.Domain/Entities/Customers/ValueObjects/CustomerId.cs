using PointCollector.Domain.Common.Models;

namespace PointCollector.Domain.Entities.Customers.ValueObjects
{
    public class CustomerId : ValueObject
    {
        public Guid Id { get; }
        private CustomerId()
        {

        }
        private CustomerId(Guid id)
        {
            Id = id;
        }

        public static CustomerId Create()
        {
            return new CustomerId(Guid.NewGuid());
        }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
        }
    }
}
