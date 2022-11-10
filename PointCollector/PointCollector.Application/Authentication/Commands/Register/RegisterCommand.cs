using ErrorOr;
using MediatR;
using PointCollector.Application.Authentication.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointCollector.Application.Authentication.Commands.Register
{
    public record RegisterCommand(
        string firstName,
        string lastName,
        string email,
        string password) : IRequest<ErrorOr<AuthenticationResult>>;
}
