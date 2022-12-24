using Mapster;
using PointCollector.Application.Workspaces.Commands.Register;
using PointCollector.Contracts.Workspaces;


namespace PointCollector.API.Common.Mapping
{
    public class WorkspaceMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<WorkspaceRegistrationRequest, WorkspaceRegisterCommand>();
        }
    }
}
