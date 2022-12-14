
namespace PointCollector.Domain.Entities.Customers.Rules
{
    public interface ICustomerUniquenessChecker
    {
        bool IsUnique(string customerEmail);
    }
}
