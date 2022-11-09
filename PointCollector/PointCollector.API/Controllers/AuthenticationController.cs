using Microsoft.AspNetCore.Mvc;
using PointCollector.Contracts.Authentication;
using PointCollector.Application.Services.Authentication;
using ErrorOr;

namespace PointCollector.API.Controllers;


[Route("auth")]
public class AuthenticationController : ApiController
{
    private readonly IAuthenticationService _authenticaionService;
    public AuthenticationController(IAuthenticationService authenticaionService)
    {
        _authenticaionService = authenticaionService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegistrationRequest request)
    {
        ErrorOr<AuthenticationResult> registerResult = _authenticaionService.Register(
            request.FirstName,
            request.LastName, 
            request.Email, 
            request.Password);

        
        return registerResult.Match(
            authResult => Ok(MapAuthResult(authResult)),
            errors => Problem(errors));
    }

    

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        ErrorOr<AuthenticationResult> loginResult = _authenticaionService.Login(
                    request.Email, 
                    request.Password);
        
        
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

