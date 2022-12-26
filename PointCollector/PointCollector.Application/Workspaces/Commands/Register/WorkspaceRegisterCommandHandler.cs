using ErrorOr;
using MediatR;
using PointCollector.Application.Common.Interfaces.Persistence.Workspaces;
using PointCollector.Application.Workspaces.Models;
using PointCollector.Domain.Common.Errors;
using PointCollector.Domain.Entities.Workspaces;
using PointCollector.Domain.Entities.Workspaces.Exceptions;
using PointCollector.Domain.Entities.Workspaces.Rules;
using PointCollector.Domain.Entities.Workspaces.ValueObjects;
using static PointCollector.Domain.Common.Globals;

namespace PointCollector.Application.Workspaces.Commands.Register
{
    public class WorkspaceRegisterCommandHandler : IRequestHandler<WorkspaceRegisterCommand, ErrorOr<WorkspaceModel>>
    {
        private readonly IWorkspaceRepository _workspaceRepository;
        private readonly IWorkspaceUniquenessChecker _workspaceUniquenessChecker;

        public WorkspaceRegisterCommandHandler(IWorkspaceRepository workspaceRepository, IWorkspaceUniquenessChecker workspaceUniquenessChecker)
        {
            _workspaceRepository = workspaceRepository;
            _workspaceUniquenessChecker = workspaceUniquenessChecker;
        }
        public async Task<ErrorOr<WorkspaceModel>> Handle(WorkspaceRegisterCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var address = new Address(command.addressStreet, command.addressCity, command.addressState, command.addressCountry, command.addressZipCode);
                var workspace = Workspace.Create(command.name, (WorkspaceType)command.rtype, address, _workspaceUniquenessChecker);

                await _workspaceRepository.Add(workspace);
                
                var ws = new WorkspaceModel(workspace.Name, (WorkspaceType)workspace.Type);
                return ws;
            }
            catch(WorkspaceNameMustBeUniqueException ex)
            {
                return Errors.Workspace.DuplicateName;
            }
        }
    }
}
