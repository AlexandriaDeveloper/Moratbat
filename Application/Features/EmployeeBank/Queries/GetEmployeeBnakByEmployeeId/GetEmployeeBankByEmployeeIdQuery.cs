
using Application.Common;
using Application.Common.Messaging;
using AutoMapper;
using Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.EmployeeBank.Queries.GetEmployeeBnakByEmployeeId
{
    public record GetEmployeeBankByEmployeeIdQuery(int employeeId) :IQuery<EmployeeBankDto?>;
    public class GetEmployeeBankByEmployeeIdQueryHandler : IQueryHandler<GetEmployeeBankByEmployeeIdQuery, EmployeeBankDto?>
    {
        private readonly IUOW _uow;
        private readonly IMapper _mapper;

        public GetEmployeeBankByEmployeeIdQueryHandler(IUOW uow ,IMapper mapper)
        {
            this._uow = uow;
            this._mapper = mapper;
        }

        public async Task<Result<EmployeeBankDto?>> Handle(GetEmployeeBankByEmployeeIdQuery request, CancellationToken cancellationToken)
        {
            Domain.EmployeeBankAccountModel employeeBank = _uow.EmployeeBankRepo.GetQueryable()
            .Include(x => x.Bank)
            .Include(x => x.Bank.Bank)
            .Where(x => x.EndAt.HasValue==false)
            .FirstOrDefault(x => x.EmployeeId==request.employeeId);


              if(employeeBank is null){
              return Result<EmployeeBankDto>.Failure(new Error("404","الموظف غير مسجل له حساب بنكى "));
              }  


            var bankToReturn = new EmployeeBankDto(){
                BankId=employeeBank.BankId,
                BankName=employeeBank.Bank.Bank.Name,
                BranchName=employeeBank.Bank.Name,
                AccountNumber= employeeBank.EmployeeAccountNumber,
                StartFrom= DateOnly.FromDateTime( employeeBank.StartFrom)
              
            };
         

            return  Result<EmployeeBankDto>.Success(bankToReturn);
        }
    }
}