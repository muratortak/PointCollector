using ErrorOr;
using MediatR;
using PointCollector.Application.Workspaces.Models;
using static PointCollector.Domain.Common.Globals;

namespace PointCollector.Application.Workspaces.Commands.Register
{
    public class WorkspaceRegisterCommand : IRequest<ErrorOr<WorkspaceModel>>
    {
        public string name { get; set; }
        public int rtype { get; set; }
        public string addressStreet { get; set; }
        public string addressCity { get; set; }
        public string addressState { get; set; }
        public string addressCountry { get; set; }
        public string addressZipCode { get; set; }
    }
}
