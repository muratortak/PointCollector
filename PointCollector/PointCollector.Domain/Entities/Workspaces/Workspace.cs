using PointCollector.Domain.Common.Interfaces;
using PointCollector.Domain.Common.Models;
using PointCollector.Domain.Entities.Workspaces.Exceptions;
using PointCollector.Domain.Entities.Workspaces.Rules;
using PointCollector.Domain.Entities.Workspaces.ValueObjects;
using static PointCollector.Domain.Common.Globals;

namespace PointCollector.Domain.Entities.Workspaces
{
    public class Workspace : Entity<WorkspaceId>, IAggregateRoot
    {
        private Workspace()
        {
            // required by EF
        }

        private Workspace(string name, WorkspaceType type, Address address) : base(WorkspaceId.Create())
        {
            Id = base.Id;
            Name = name;
            Type = (int)type;
            Address = address;
        }

        public static Workspace Create(string name, WorkspaceType type, Address address, IWorkspaceUniquenessChecker workspaceUniquenessChecker)
        {
            CheckRule(new WorkspaceNameMustBeUniqueRule(workspaceUniquenessChecker, name), typeof(WorkspaceNameMustBeUniqueException));
            return new Workspace(name, type, address);
        }
        public static Workspace Create(string name, WorkspaceType type, Address address)
        {
            return new Workspace(name, type, address);
        }

        public WorkspaceId Id { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public virtual Address? Address { get; private set; }
    }
}
