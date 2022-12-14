using FluentValidation;

namespace PointCollector.Application.Authentication.Commands.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(x => x.firstName).NotEmpty().NotEqual("test");
            RuleFor(x => x.lastName).NotEmpty();
            RuleFor(x => x.email).NotEmpty();
            RuleFor(x => x.password).NotEmpty();
        }
    }
}
