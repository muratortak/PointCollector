using PointCollector.Domain.Entities;

namespace PointCollector.Application.Authentication.Common;

public record AuthenticationResult(
    User User,
    string Token);

