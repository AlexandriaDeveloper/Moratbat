
using Application.Common.Messaging;
using Application.Common;
using AutoMapper;
using Domain.Interfaces.Repository;

namespace Application.Features.EmployeeBank.Commands.CloseEmployeeBankAccount
{
    public record CloseEmployeeBankAccountCommand(CloseEmployeeBankAccountRequest model) : Common.Messaging.ICommand;
    public class CloseEmployeeBankAccountCommandHandler : ICommandHandler<CloseEmployeeBankAccountCommand>
    {
        private readonly IUOW _uow;
        private readonly IMapper _mapper;

        public CloseEmployeeBankAccountCommandHandler(IUOW uow, IMapper mapper)
        {
            this._uow = uow;
            this._mapper = mapper;
        }
        public async Task<Result> Handle(CloseEmployeeBankAccountCommand request, CancellationToken cancellationToken)
        {
            var employeeBankAccount = _uow.EmployeeBankRepo.GetEmployeeBankAccount(request.model.EmployeeId, request.model.BankId);
            if (employeeBankAccount == null)
            {
                return Result.Failure(new Error("404", "الحساب غير موجود"));
            }

            _uow.EmployeeBankRepo.Update(employeeBankAccount);

            //var emp = await _uow.EmployeeRepo.GetByIdAsync(employeeBankAccount.EmployeeId);
            // if (emp.PaymentMethodA == Domain.Constants.PaymentMethodEnum.PersonalAccount)
            // {
            //     if (!string.IsNullOrEmpty(emp.TabCode))
            //     {
            //         emp.PaymentMethodA = Domain.Constants.PaymentMethodEnum.Atm;
            //     }
            //     else
            //     {
            //         emp.PaymentMethodA = Domain.Constants.PaymentMethodEnum.PostalTransfer;
            //     }
            // }
            // _uow.EmployeeRepo.Update(emp);

            // var result = await _uow.SaveChangesAsync(cancellationToken);
            // if (result.IsFailure)
            // {
            //     return Result.Failure(new Error(result.ErrorCode, result.Message));
            // }
            return Result.Success();
        }
    }
}