using PointCollector.Domain.Entities.Customers;

namespace PointCollector.Application.Common.Interfaces.Authentication;
public interface IJwtTokenGenerator
{
    string GenerateToken(Customer user);
}

