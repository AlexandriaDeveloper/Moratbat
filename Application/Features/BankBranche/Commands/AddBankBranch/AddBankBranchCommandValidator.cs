using FluentValidation;

namespace Application.Features.BankBranche.Commands.AddBankBranch
{
    public class AddBankBranchCommandValidator : AbstractValidator<AddBankBranchCommand>
    {
        public AddBankBranchCommandValidator()
        {
            RuleFor(x => x.model).NotNull();
            RuleFor(x => x.model.Name).NotEmpty().NotNull();
            RuleFor(x => x.model.BankId).NotNull();

        }
    }
}