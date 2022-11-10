using ErrorOr;
using MediatR;
using PointCollector.Application.Authentication.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointCollector.Application.Authentication.Queries.Login
{
    public record LoginQuery(string email, string password) : IRequest<ErrorOr<AuthenticationResult>>;
}
