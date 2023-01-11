using PointCollector.Domain.Common.Models;

namespace PointCollector.Domain.Entities.Customers.ValueObjects
{
    public class Point : ValueObject
    {
        public Point() 
        {

        }

        public Point(Guid workspaceId, decimal totalPoint)
        {
            WorkspaceId = workspaceId;
            CollectedPoint = totalPoint;
        }
        public int PointId { get; set; }
        public Guid WorkspaceId { get; set; }
        public decimal CollectedPoint { get; set; }
        public DateTime AddedAt { get; set; }
        public virtual Customer Customer { get; set; }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return WorkspaceId;
            yield return CollectedPoint;
        }
    }
}
