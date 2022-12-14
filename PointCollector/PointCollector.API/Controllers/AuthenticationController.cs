using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using PointCollector.Contracts.Authentication;
using MediatR;
using PointCollector.Application.Authentication.Commands.Register;
using PointCollector.Application.Authentication.Queries.Login;
using PointCollector.Application.Authentication.Common;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
//using Serilog;

namespace PointCollector.API.Controllers;


[Route("auth")]
[AllowAnonymous]
public class AuthenticationController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;
    private readonly ILogger<AuthenticationController> _logger;
    public AuthenticationController(ISender mediator, IMapper mapper, ILogger<AuthenticationController> logger)
    {
        _mediator = mediator;
        _mapper = mapper;
        _logger = logger;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegistrationRequest request)
    {
        _logger.LogInformation("test");
        var command = _mapper.Map<RegisterCommand>(request);
        ErrorOr<AuthenticationResult> registerResult = await _mediator.Send(command);
        
        return registerResult.Match(
            authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
            errors => Problem(errors));
    }

    

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {

        var query = _mapper.Map<LoginQuery>(request);

        ErrorOr<AuthenticationResult> loginResult = await _mediator.Send(query);
 
        return loginResult.Match(
            authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
            errors => Problem(errors));
    }

}

