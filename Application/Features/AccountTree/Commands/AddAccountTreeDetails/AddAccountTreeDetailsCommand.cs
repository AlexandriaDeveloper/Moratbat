using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Common;
using Application.Common.Messaging;
using Application.Features.BudgetItems;
using AutoMapper;

namespace Application.Features.AccountTree.Commands.AddAccountTreeDetails
{
    public record AddAccountTreeDetailsCommand(AccountTreeDetailsDto model) : ICommand;
    public class AddAccountTreeDetailsCommandHandler : ICommandHandler<AddAccountTreeDetailsCommand>
    {
        private readonly IMapper _mapper;
        private readonly IUOW _uow;
        public AddAccountTreeDetailsCommandHandler(IUOW uow, IMapper mapper)
        {
            this._uow = uow;
            this._mapper = mapper;

        }
        public async Task<Result> Handle(AddAccountTreeDetailsCommand request, CancellationToken cancellationToken)
        {
            AccountTreeDetailsModel accountTreeDetailsToDb = _mapper.Map<AccountTreeDetailsModel>(request.model);
            await _uow.AccountTreeDetailsRepo.Insert(accountTreeDetailsToDb, cancellationToken);
            var result = await _uow.SaveChangesAsync(cancellationToken);
            if (result.IsFailure)
            {
                return Result.Failure(new Error(result.ErrorCode, result.Message));
            }
            return Result.Success();
        }
    }
}