using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using PointCollector.Contracts.Authentication;
using MediatR;
using PointCollector.Application.Authentication.Commands.Register;
using PointCollector.Application.Authentication.Queries.Login;
using PointCollector.Application.Authentication.Common;

namespace PointCollector.API.Controllers;


[Route("auth")]
public class AuthenticationController : ApiController
{
    private readonly ISender _mediator;
    public AuthenticationController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegistrationRequest request)
    {
        var command = new RegisterCommand(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password);

        ErrorOr<AuthenticationResult> registerResult = await _mediator.Send(command);
        
        return registerResult.Match(
            authResult => Ok(MapAuthResult(authResult)),
            errors => Problem(errors));
    }

    

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = new LoginQuery(
            request.Email,
            request.Password);

        ErrorOr<AuthenticationResult> loginResult = await _mediator.Send(query);
 
        return loginResult.Match(
            authResult => Ok(MapAuthResult(authResult)),
            errors => Problem(errors));
    }

    private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
    {
        return new AuthenticationResponse(
                authResult.Id,
                authResult.FirstName,
                authResult.LastName,
                authResult.Email,
                authResult.Token);
    }
}

