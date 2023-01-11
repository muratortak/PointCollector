using FluentValidation;

namespace PointCollector.Application.Customers.Commands.CollectPoint
{
    public class CollectPointCommandValidator : AbstractValidator<CollectPointCommand>
    {
        public CollectPointCommandValidator()
        {
            RuleFor(x => x.UserEmail).NotEmpty();
        }
    }
}
