
using Application.Common;
using Application.Common.Messaging;
using Application.Features.Bank.Queries.GetBanks;
using AutoMapper;
using Domain;
using Domain.Interfaces.Repository;

namespace Application.Features.Bank.Commands.AddBank
{
    public record AddBankCommand(BankDto Bank) : ICommand;
    public class AddBankCommandHandler : ICommandHandler<AddBankCommand>
    {
        private readonly IUOW _uow;
        private readonly IMapper _mapper;

        public AddBankCommandHandler(IUOW uow, IMapper mapper)
        {
            this._uow = uow;
            this._mapper = mapper;
        }

        public async Task<Result> Handle(AddBankCommand request, CancellationToken cancellationToken)
        {
            BankModel bank = _mapper.Map<BankModel>(request.Bank);

            await _uow.BankRepo.Insert(bank, cancellationToken);
            var result = await _uow.SaveChangesAsync(cancellationToken);
            if (result.IsFailure)
            {
                return Result.Failure(new Error(result.ErrorCode, result.Message));
            }
            return Result.Success();
        }
    }
}