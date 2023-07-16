
using Application.Common;
using Application.Common.Messaging;
using AutoMapper;

namespace Application.Features.BankBranche.Commands.AddBankBranch
{
    public record AddBankBranchCommand(BankBranchDto model) : ICommand;
    public class AddBankBranchCommandHandler : ICommandHandler<AddBankBranchCommand>
    {
        private readonly IUOW _uow;
        private readonly IMapper _mapper;

        public AddBankBranchCommandHandler(IUOW uow, IMapper mapper)
        {
            this._uow = uow;
            this._mapper = mapper;
        }
        public async Task<Result> Handle(AddBankBranchCommand request, CancellationToken cancellationToken)
        {
            var bankBranchToDb = _mapper.Map<BankBranchModel>(request.model);
            var bankBranchToDb2 = _mapper.Map<BankBranchModel>(request.model);
            await _uow.BankBranchRepo.Insert(bankBranchToDb, cancellationToken);
            bankBranchToDb2.Name = bankBranchToDb2.Name + "-مدفوعات الموردين";
            await _uow.BankBranchRepo.Insert(bankBranchToDb2, cancellationToken);
            var result = await _uow.SaveChangesAsync(cancellationToken);
            if (result.IsFailure)
            {
                return Result.Failure(new Error(result.ErrorCode, result.Message));
            }
            return Result.Success();
        }
    }
}