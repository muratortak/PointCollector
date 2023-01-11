using Mapster;
using PointCollector.Application.Customers.Commands.CollectPoint;
using PointCollector.Application.Customers.ViewModels;
using PointCollector.Contracts.Customers;

namespace PointCollector.API.Common.Mapping
{
    public class CustomerMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CollectPointRequest, CollectPointCommand>()
                //.Map(dest => dest.WorkspaceId, src => src.WorkspaceId)
                //.Map(dest => dest.UserId, src => src.UserId)
                .Map(dest => dest.Points, src => src.PointsToCollect);

            config.NewConfig<CollectPointViewModel, CollectPointResponse>();

        }
    }
}
