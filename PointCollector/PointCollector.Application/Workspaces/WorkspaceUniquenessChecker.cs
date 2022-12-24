using PointCollector.Application.Common.Interfaces.Persistence.Workspaces;
using PointCollector.Domain.Entities.Workspaces.Rules;

namespace PointCollector.Application.Workspaces
{
    public class WorkspaceUniquenessChecker : IWorkspaceUniquenessChecker
    {
        private readonly IWorkspaceRepository _workspaceRepository;
        public WorkspaceUniquenessChecker(IWorkspaceRepository workspaceRepository)
        {
            _workspaceRepository = workspaceRepository;
        }
        public async Task<bool> IsUnique(string customerEmail)
        {
            return await _workspaceRepository.GetWorkspaceByName(customerEmail) is null;
        }
    }
}
