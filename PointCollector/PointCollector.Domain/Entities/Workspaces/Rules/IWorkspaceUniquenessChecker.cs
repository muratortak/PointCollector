
namespace PointCollector.Domain.Entities.Workspaces.Rules
{
    public interface IWorkspaceUniquenessChecker
    {
        Task<bool> IsUnique(string workspaceName);
    }
}
