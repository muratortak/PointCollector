using PointCollector.Domain.Common.Models;

namespace PointCollector.Domain.Entities.Account.ValueObjects
{
    public class AccountId : ValueObject
    {
        public Guid Id { get; }
        private AccountId()
        {

        }

        private AccountId(Guid id)
        {
            Id = id;
        }

        public static AccountId Create()
        {
            return new AccountId(Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
        }
    }
}
