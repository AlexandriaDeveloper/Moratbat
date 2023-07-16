using FluentValidation;

namespace Application.Features.AccountTree.Commands.AddAccountTreeDetails
{
    public class AddAccountTreeDetailsCommandValidator : AbstractValidator<AddAccountTreeDetailsCommand>
    {
        public AddAccountTreeDetailsCommandValidator()
        {

            RuleFor(x => x.model).NotNull();

            RuleFor(x => x.model.AccountTreeId).NotEmpty().NotNull();
            RuleFor(x => x.model.Name).NotEmpty().NotNull();
            RuleFor(x => x.model.Id).NotEmpty().NotNull();

        }
    }
}