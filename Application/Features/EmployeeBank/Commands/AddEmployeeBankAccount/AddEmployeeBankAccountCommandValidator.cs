using FluentValidation;

namespace Application.Features.EmployeeBank.Commands.AddEmployeeBankAccount
{
    public class AddEmployeeBankAccountCommandValidator : AbstractValidator<EditEmployeeBankAccountCommand>
    {
        public AddEmployeeBankAccountCommandValidator()
        {
            RuleFor(x => x.EmployeeBankAccount).NotNull();
            RuleFor(x => x.EmployeeBankAccount.EmployeeId).NotEmpty().NotNull();
            RuleFor(x => x.EmployeeBankAccount.BranchAId).NotNull();
            RuleFor(x => x.EmployeeBankAccount.AccountANumber).NotEmpty().NotNull();
            RuleFor(x => x.EmployeeBankAccount.BranchBId).NotNull();
            RuleFor(x => x.EmployeeBankAccount.AccountBNumber).NotEmpty().NotNull();


        }
    }
}