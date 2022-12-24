
namespace PointCollector.Contracts.Workspaces
{
    public class WorkspaceRegistrationRequest 
    {
        public string name { get; set; }
        public int rtype { get; set; }
        public string addressStreet { get; set; }
        public string addressCity { get; set; }
        public string addressState { get; set; }
        public string addressCountry { get; set; }
        public string addressZipCode { get; set; }
    };
}
