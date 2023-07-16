
using Application.Common;
using Application.Common.Messaging;
using AutoMapper;
using Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.EmployeeBank.Queries.GetEmployeeBnakByEmployeeId
{
    public record GetEmployeeBankByEmployeeIdQuery(int employeeId) : IQuery<EmployeeBankDto>;
    public class GetEmployeeBankByEmployeeIdQueryHandler : IQueryHandler<GetEmployeeBankByEmployeeIdQuery, EmployeeBankDto>
    {
        private readonly IUOW _uow;
        private readonly IMapper _mapper;

        public GetEmployeeBankByEmployeeIdQueryHandler(IUOW uow, IMapper mapper)
        {
            this._uow = uow;
            this._mapper = mapper;
        }

        public async Task<Result<EmployeeBankDto>> Handle(GetEmployeeBankByEmployeeIdQuery request, CancellationToken cancellationToken)
        {
            EmployeeBankAccountModel employeeBank = await _uow.EmployeeBankRepo.GetQueryable()
             .Include(x => x.BankA)
             .Include(x => x.BankB)
             .Include(x => x.BankA.Bank)
             .Include(x => x.BankB.Bank)
             .Where(x => x.EmployeeId == request.employeeId)
            .FirstOrDefaultAsync(cancellationToken);



            if (employeeBank is null)
            {
                return Result<EmployeeBankDto>.Failure(new Error("404", "الموظف غير مسجل له حساب بنكى "));
            }


            var bankToReturn = (new EmployeeBankDto
            {

                BankAId = employeeBank.BankA.Bank.Id,
                BankAName = employeeBank.BankA.Bank.Name,
                BranchAId = employeeBank.BankA.Id,
                BranchAName = employeeBank.BankA.Name,
                AccountANumber = employeeBank.AccountANumber,

                BankBId = employeeBank.BankB.BankId,
                BankBName = employeeBank.BankB.Bank.Name,
                BranchBId = employeeBank.BankB.Id,
                BranchBName = employeeBank.BankB.Name,
                AccountBNumber = employeeBank.AccountBNumber,

            });




            return Result<EmployeeBankDto>.Success(bankToReturn);
        }
    }
}