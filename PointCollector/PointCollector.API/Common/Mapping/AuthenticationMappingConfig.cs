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
                //.Map(dest => dest.Id, src => src.User.Id.Id) // FIX THIS USE EXPLICIT PROPERTIES FROM AUTHRESULT INSTEAD OF USER OBJECT
                .Map(dest => dest.FirstName, src => src.User.FirstName)
                .Map(dest => dest.LastName, src => src.User.LastName)
                .Map(dest => dest.Email, src => src.User.Email);
        }
    }
}
