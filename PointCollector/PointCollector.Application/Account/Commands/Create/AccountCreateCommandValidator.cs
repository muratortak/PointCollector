using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointCollector.Application.Account.Commands.Create
{
    public class AccountCreateCommandValidator : AbstractValidator<AccountCreateCommand>
    {
        public AccountCreateCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.AccountStatus).NotEmpty();
        }
    }
}
