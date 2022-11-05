using Microsoft.AspNetCore.Mvc;
using PointCollector.Contracts.Authentication;
using PointCollector.Application.Services.Authentication;

namespace PointCollector.API.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase 
{
    private readonly IAuthenticationService _authenticaionService;
    public AuthenticationController(IAuthenticationService authenticaionService)
    {
        _authenticaionService = authenticaionService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegistrationRequest request)
    {
        var authResult = _authenticaionService.Register(
            request.FirstName, 
            request.LastName, 
            request.Email, 
            request.Password);

        var response = new AuthenticationResponse(
            authResult.Id, 
            authResult.FirstName, 
            authResult.LastName, 
            authResult.Email, 
            authResult.Token);

        return Ok(response);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var authResult = _authenticaionService.Login(
            request.Email, 
            request.Password);

        var response = new AuthenticationResponse(
            authResult.Id, 
            authResult.FirstName, 
            authResult.LastName, 
            authResult.Email, 
            authResult.Token);
            
        return Ok(response);
    }

}