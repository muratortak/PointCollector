using PointCollector.Domain.Entities.Customers;

namespace PointCollector.Application.Authentication.Common;

public record AuthenticationResult(
    Customer User,
    string Token);

