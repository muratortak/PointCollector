using PointCollector.Domain.Common.Interfaces;

namespace PointCollector.Domain.Entities.Workspaces.Rules
{
    public class WorkspaceNameMustBeUniqueRule : IBusinessRule
    {
        private IWorkspaceUniquenessChecker _workspaceUniquenessChecker;
        private string _workspaceName;
        public WorkspaceNameMustBeUniqueRule(IWorkspaceUniquenessChecker workspaceUniquenessChecker, string workspaceName)
        {
            _workspaceUniquenessChecker = workspaceUniquenessChecker;
            _workspaceName = workspaceName;
        }

        public bool IsBroken() => !_workspaceUniquenessChecker.IsUnique(_workspaceName).GetAwaiter().GetResult();
        public string Message => "Workspace with this name already exits";

    }
}
