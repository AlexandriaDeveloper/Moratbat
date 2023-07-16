
using Application.Common;
using Application.Common.Messaging;
using Application.Features.BudgetItems;
using AutoMapper;

namespace Application.Features.AccountTree.Commands.AddAccountTree
{

    public record AddAccountTreeCommand(AccountTreeDto model) : ICommand;
    public class AddAccountTrreeCommandHandler : ICommandHandler<AddAccountTreeCommand>
    {
        private readonly IUOW _uow;
        private readonly IMapper _mapper;
        public AddAccountTrreeCommandHandler(IUOW uow, IMapper mapper)
        {
            this._mapper = mapper;
            this._uow = uow;

        }
        public async Task<Result> Handle(AddAccountTreeCommand request, CancellationToken cancellationToken)
        {
            AccountTreeModel accountTreeToDb = _mapper.Map<AccountTreeModel>(request.model);
            await _uow.AccountTreeRepo.Insert(accountTreeToDb, cancellationToken);
            var result = await _uow.SaveChangesAsync(cancellationToken);
            if (result.IsFailure)
            {
                return Result.Failure(new Error(result.ErrorCode, result.Message));
            }
            return Result.Success();
        }
    }
}