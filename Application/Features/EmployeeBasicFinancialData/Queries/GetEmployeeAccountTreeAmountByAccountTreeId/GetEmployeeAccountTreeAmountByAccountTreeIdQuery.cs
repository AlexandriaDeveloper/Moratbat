
using Application.Common;
using Application.Common.Messaging;
using Application.Features.EmployeeBasicFinancialData.UploadEmployeeBasicFinancialData;
using AutoMapper;

namespace Application.Features.EmployeeBasicFinancialData.Queries.GetEmployeeAccountTreeAmountByAccountTreeId
{
    public record GetEmployeeAccountTreeAmountByAccountTreeIdQuery(int employeeId, int accountTreeId, DateTime peekDate) : IQuery<decimal>;
    public class GetEmployeeAccountTreeAmountByAccountTreeIdQueryHandler : IQueryHandler<GetEmployeeAccountTreeAmountByAccountTreeIdQuery, decimal>
    {
        private readonly IMapper _mapper;
        private readonly IUOW _uow;
        public GetEmployeeAccountTreeAmountByAccountTreeIdQueryHandler(IUOW uow, IMapper mapper)
        {
            this._uow = uow;
            this._mapper = mapper;

        }
        public async Task<Result<decimal>> Handle(GetEmployeeAccountTreeAmountByAccountTreeIdQuery request, CancellationToken cancellationToken)
        {
            var amount = _uow.EmployeeBasicFinancialDataRepo.GetQueryable()
                      .Where(x => x.EmployeeId == request.employeeId &&
                        x.StartDate <= request.peekDate
                        && x.AccountTreeDetailsAccountTreeId == request.accountTreeId)
                        .Sum(x => x.Amount);
            if (amount == null)
            {
                return Result<decimal>.Failure(new Error("404", "الملف غير موجود"));
            }

            return Result<decimal>.Success(amount);
        }
    }
}