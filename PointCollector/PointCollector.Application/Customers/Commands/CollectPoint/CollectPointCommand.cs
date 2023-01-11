using ErrorOr;
using MediatR;
using PointCollector.Application.Customers.ViewModels;

namespace PointCollector.Application.Customers.Commands.CollectPoint
{
    public class CollectPointCommand : IRequest<ErrorOr<CollectPointViewModel>>
    {
        public string UserEmail { get; set; }
        public Guid WorkspaceId { get; set; }
        public decimal Points { get; set; }
    }
}
