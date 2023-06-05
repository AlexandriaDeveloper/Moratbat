using Application.Features.Bank.Queries.GetBanks;
using FluentValidation;

namespace Application.Features.Bank.Commands.AddBank
{
    public class AddBankCommandValidator : AbstractValidator<BankDto>
    {
        public AddBankCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();

        }
    }
}