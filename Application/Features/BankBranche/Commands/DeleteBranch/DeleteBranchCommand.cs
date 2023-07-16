using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Common;
using Application.Common.Messaging;
using AutoMapper;
using Domain.Interfaces.Repository;

namespace Application.Features.BankBranche.Commands.DeleteBranch
{
    public record DeleteBranchCommand(int branchId) : ICommand;
    public class DeleteBranchCommandHandler : ICommandHandler<DeleteBranchCommand>
    {
        private readonly IUOW _uow;
        private readonly IMapper _mapper;

        public DeleteBranchCommandHandler(IUOW uow, IMapper mapper)
        {
            this._uow = uow;
            this._mapper = mapper;
        }
        public async Task<Result> Handle(DeleteBranchCommand request, CancellationToken cancellationToken)
        {
            var bankBranch = await _uow.BankBranchRepo.GetByIdAsync(request.branchId);
            if (bankBranch is null)
            {
                return Result.Failure(new Error("404", "خطأ الفرع غير موجود"));
            }
            _uow.BankBranchRepo.Delete(bankBranch);
            var result = await _uow.SaveChangesAsync(cancellationToken);
            if (result.IsFailure)
            {
                return Result.Failure(new Error(result.ErrorCode, result.Message));
            }
            return Result.Success();
        }
    }
}