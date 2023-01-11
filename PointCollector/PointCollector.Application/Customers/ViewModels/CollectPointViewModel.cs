
namespace PointCollector.Application.Customers.ViewModels
{
    public class CollectPointViewModel
    {
        public string UserFirstName { get; set; } = null!;
        public decimal CollectedPoint { get; set; }
        public decimal TotalPoint { get; set; }
    }
}
