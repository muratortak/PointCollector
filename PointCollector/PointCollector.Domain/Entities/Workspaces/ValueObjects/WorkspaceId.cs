using PointCollector.Domain.Common.Models;

namespace PointCollector.Domain.Entities.Workspaces.ValueObjects
{
    public class WorkspaceId : ValueObject
    {
        public Guid Id { get; }

        private WorkspaceId()
        {

        }

        private WorkspaceId(Guid id)
        {
            Id = id;
        }

        public static WorkspaceId Create()
        {
            return new WorkspaceId(Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
        }
    }
}
