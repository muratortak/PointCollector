using ErrorOr;
using MediatR;
using PointCollector.Application.Account.Models;

using static PointCollector.Domain.Common.Globals;

namespace PointCollector.Application.Account.Commands.Create
{
    public record AccountCreateCommand : IRequest<ErrorOr<AccountModel>>
    {
        public Guid UserId { get; set; }
        public AccountStatus AccountStatus { get; set; }
    }
}
