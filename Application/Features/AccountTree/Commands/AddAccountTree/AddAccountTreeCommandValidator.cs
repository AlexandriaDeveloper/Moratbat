using FluentValidation;

namespace Application.Features.AccountTree.Commands.AddAccountTree
{
    public class AddAccountTreeCommandValidator : AbstractValidator<AddAccountTreeCommand>
    {
        public AddAccountTreeCommandValidator()
        {
            RuleFor(x => x.model).NotNull();

            RuleFor(x => x.model.AccountParentId).NotEmpty().NotNull();
            RuleFor(x => x.model.Name).NotEmpty().NotNull();
            RuleFor(x => x.model.Id).NotEmpty().NotNull();

        }
    }
}