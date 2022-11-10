using Mapster;
using PointCollector.Application.Authentication.Commands.Register;
using PointCollector.Application.Authentication.Common;
using PointCollector.Application.Authentication.Queries.Login;
using PointCollector.Contracts.Authentication;

namespace PointCollector.API.Common.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<RegistrationRequest, RegisterCommand>();

            config.NewConfig<LoginRequest, LoginQuery>();

            config.NewConfig<AuthenticationResult, AuthenticationResponse>()
                .Map(dest => dest, src => src.User);
        }
    }
}
