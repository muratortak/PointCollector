using FluentValidation;

namespace PointCollector.Application.Workspaces.Commands.Register
{
    public class WorkspaceRegisterCommandValidator : AbstractValidator<WorkspaceRegisterCommand>
    {
        public WorkspaceRegisterCommandValidator()
        {
            RuleFor(x => x.name).NotEmpty().NotEqual("test");
        }
    }
}
