using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PointCollector.Application.Customers.Commands.CollectPoint;
using PointCollector.Application.Customers.ViewModels;
using PointCollector.Contracts.Customers;

namespace PointCollector.API.Controllers
{
    [Route("point")]
    [AllowAnonymous]
    public class PointController : ApiController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<AuthenticationController> _logger;
        public PointController(ISender mediator, IMapper mapper, ILogger<AuthenticationController> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost("collect")]
        public async Task<IActionResult> Register(CollectPointRequest request)
        {
            _logger.LogInformation("test");
            var command = _mapper.Map<CollectPointCommand>(request);
            ErrorOr<CollectPointViewModel> registerResult = await _mediator.Send(command);

            return registerResult.Match(
                authResult => Ok(_mapper.Map<CollectPointViewModel>(authResult)),
                errors => Problem(errors));
        }


    }
}
