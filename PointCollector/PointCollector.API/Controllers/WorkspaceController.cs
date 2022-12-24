using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using PointCollector.Application.Workspaces.Commands.Register;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using PointCollector.Application.Workspaces.Models;
using PointCollector.Contracts.Workspaces;
//using Serilog;

namespace PointCollector.API.Controllers;


[Route("workspace")]
[AllowAnonymous]
public class WorkspaceController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;
    private readonly ILogger<WorkspaceController> _logger;
    public WorkspaceController(ISender mediator, IMapper mapper, ILogger<WorkspaceController> logger)
    {
        _mediator = mediator;
        _mapper = mapper;
        _logger = logger;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(WorkspaceRegistrationRequest request)
    {
        _logger.LogInformation("test");
        var command = _mapper.Map<WorkspaceRegisterCommand>(request);
        ErrorOr<WorkspaceModel> registerResult = await _mediator.Send(command);
        
        return registerResult.Match(
            workspaceResult => Ok(workspaceResult),
            errors => Problem(errors));
    }
}

