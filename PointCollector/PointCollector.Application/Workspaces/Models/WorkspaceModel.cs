using static PointCollector.Domain.Common.Globals;

namespace PointCollector.Application.Workspaces.Models
{
    public record WorkspaceModel(
        string Name,
        WorkspaceType Type);
}
