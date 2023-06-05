
using Application.Features.Bank.Queries.GetBanks;
using Application.Common.Messaging;
using Application.Common;
using Domain.Interfaces.Repository;
using AutoMapper;

namespace Application.Features.Bank.Commands.DeleteBank
{
    public record DeleteBankCommand(int bankId) : ICommand;

    public class DeleteBankCommandHandler : ICommandHandler<DeleteBankCommand>
    {
        private readonly IUOW _uow;
        private readonly IMapper _mapper;

        public DeleteBankCommandHandler(IUOW uow, IMapper mapper)
        {
            this._uow = uow;
            this._mapper = mapper;
        }

        public async Task<Result> Handle(DeleteBankCommand request, CancellationToken cancellationToken)
        {
            var bank = await _uow.BankRepo.GetByIdAsync(request.bankId);
            if (bank is null)
            {
                return Result.Failure(new Error("404", "البنك المراد حذفة غير موجود "));
            }

            this._uow.BankRepo.Delete(bank);
            var result = await _uow.SaveChangesAsync(cancellationToken);
            if (result.IsFailure)
            {
                return Result.Failure(new Error(result.ErrorCode, result.Message));
            }
            return Result.Success();
        }
    }
}