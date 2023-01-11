using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointCollector.Contracts.Customers
{
    public class CollectPointRequest
    {
        public string UserEmail { get; set; }
        public Guid WorkspaceId { get; set; }
        public decimal PointsToCollect { get; set; }
    }
}
