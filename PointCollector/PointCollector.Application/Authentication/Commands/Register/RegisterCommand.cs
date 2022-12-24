using ErrorOr;
using MediatR;
using PointCollector.Application.Authentication.Common;

namespace PointCollector.Application.Authentication.Commands.Register
{
    public record RegisterCommand(
        string firstName,
        string lastName,
        string email,
        string password) : IRequest<ErrorOr<AuthenticationResult>>;
}
