
using Application.Common;
using Application.Common.Messaging;
using AutoMapper;
using Domain.Constants;
using Domain.Interfaces.Repository;

namespace Application.Features.EmployeeBank.Commands.DeleteEmployeeAccount
{

    public record DeleteEmployeeAccountCommand(int EmployeeId, int BankId) : ICommand;
    public class DeleteEmployeeAccountCommandHandler : ICommandHandler<DeleteEmployeeAccountCommand>
    {
        private readonly IUOW _uow;
        private readonly IMapper _mapper;

        public DeleteEmployeeAccountCommandHandler(IUOW uow, IMapper mapper)
        {
            this._uow = uow;
            this._mapper = mapper;
        }
        public async Task<Result> Handle(DeleteEmployeeAccountCommand request, CancellationToken cancellationToken)
        {

            var employeeBankAccount = _uow.EmployeeBankRepo.GetEmployeeBankAccount(request.EmployeeId, request.BankId);
            if (employeeBankAccount == null)
            {
                return Result.Failure(new Error("404", "الحساب غير موجود"));
            }

            _uow.EmployeeBankRepo.Delete(employeeBankAccount);
            var emp = await _uow.EmployeeRepo.GetByIdAsync(request.EmployeeId);
            // if (emp.PaymentMethodA == PaymentMethodEnum.PersonalAccount)
            // {
            //     if (!string.IsNullOrEmpty(emp.TabCode))
            //     {
            //         emp.PaymentMethodA = PaymentMethodEnum.Atm;
            //     }
            //     else
            //     {
            //         emp.PaymentMethodA = PaymentMethodEnum.PostalTransfer;
            //     }
            // }
            // if (emp.PaymentMethodB == PaymentMethodEnum.PersonalAccount)
            // {
            //     if (!string.IsNullOrEmpty(emp.TabCode))
            //     {
            //         emp.PaymentMethodB = PaymentMethodEnum.Atm;
            //     }
            //     else
            //     {
            //         emp.PaymentMethodB = PaymentMethodEnum.PostalTransfer;
            //     }

            // }
            _uow.EmployeeRepo.Update(emp);
            var result = await _uow.SaveChangesAsync(cancellationToken);
            if (result.IsFailure)
            {
                return Result.Failure(new Error(result.ErrorCode, result.Message));
            }
            return Result.Success();
        }
    }
}