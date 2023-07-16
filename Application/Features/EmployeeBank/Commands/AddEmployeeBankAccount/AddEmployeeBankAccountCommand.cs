using Application.Common;
using Application.Common.Messaging;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.EmployeeBank.Commands.AddEmployeeBankAccount
{
    public record EditEmployeeBankAccountCommand(EmployeeBankAccountRequest EmployeeBankAccount) : ICommand;
    public class EditEmployeeBankAccountCommandHandler : ICommandHandler<EditEmployeeBankAccountCommand>
    {
        private readonly IUOW _uow;
        private readonly IMapper _mapper;
        public EditEmployeeBankAccountCommandHandler(IUOW uow, IMapper mapper)
        {
            this._mapper = mapper;
            this._uow = uow;

        }
        public async Task<Result> Handle(EditEmployeeBankAccountCommand request, CancellationToken cancellationToken)
        {


            var employeeBankAccount = await _uow.EmployeeBankRepo.GetQueryable()
            .FirstOrDefaultAsync(x => x.EmployeeId == request.EmployeeBankAccount.EmployeeId, cancellationToken);
            if (employeeBankAccount == null)
            {
                return Result.Failure(new Error("404", "الحساب غير موجود"));
            }
            _mapper.Map<EmployeeBankAccountRequest, EmployeeBankAccountModel>(request.EmployeeBankAccount, employeeBankAccount);
            _uow.EmployeeBankRepo.Update(employeeBankAccount);
            var result = await _uow.SaveChangesAsync(cancellationToken);
            if (result.IsFailure)
            {
                return Result.Failure(new Error(result.ErrorCode, result.Message));
            }
            return Result.Success();
        }
    }
}