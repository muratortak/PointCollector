using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointCollector.Contracts.Customers
{
    public class CollectPointResponse
    {
        public string UserFirstName { get; set; }
        public decimal CollectedPoint { get; set; }
        public decimal TotalPoint { get; set; }
    }
}
