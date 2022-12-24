using PointCollector.Domain.Entities.Workspaces;

namespace PointCollector.Application.Common.Interfaces.Persistence.Workspaces
{
    public interface IWorkspaceRepository
    {
        Task<Workspace>? GetWorkspaceByName(string name);
        Task<Workspace> Add(Workspace workspace);
    }
}
