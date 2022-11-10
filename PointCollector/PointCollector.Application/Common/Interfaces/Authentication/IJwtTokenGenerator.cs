using PointCollector.Domain.Entities;

namespace PointCollector.Application.Common.Interfaces.Authentication;
public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}

