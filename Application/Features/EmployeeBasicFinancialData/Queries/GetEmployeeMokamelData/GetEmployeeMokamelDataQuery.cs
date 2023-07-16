
using Application.Common;
using Application.Common.Messaging;
using Application.Features.EmployeeBasicFinancialData.UploadEmployeeBasicFinancialData;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
namespace Application.Features.EmployeeBasicFinancialData.Queries.GetEmployeeMokamelData
{
    public record getEmployeeMokamelDataQuery(int employeeId, DateTime peekDate) : IQuery<EmployeeDataInfoDto>;
    public class GetEmployeeMokamelDataQueryHandler : IQueryHandler<getEmployeeMokamelDataQuery, EmployeeDataInfoDto>
    {
        private readonly IUOW _uow;
        private readonly IMapper _mapper;
        public GetEmployeeMokamelDataQueryHandler(IUOW uow, IMapper mapper)
        {
            this._mapper = mapper;
            this._uow = uow;

        }
        public async Task<Result<EmployeeDataInfoDto>> Handle(getEmployeeMokamelDataQuery request, CancellationToken cancellationToken)
        {
            var employee = await _uow.EmployeeRepo.GetByIdAsync(request.employeeId);
            if (employee == null)
            {
                return Result<EmployeeDataInfoDto>.Failure(new Error("404", "الموظف غير موجود"));
            }

            List<EmployeeDataDto> wazifiData = new List<EmployeeDataDto>();
            var wazifi = _uow.EmployeeBasicFinancialDataRepo.GetQueryable()
                         .Where(x => x.EmployeeId == request.employeeId &&
                           x.StartDate <= request.peekDate
                           && x.AccountTreeDetailsAccountTreeId != 21110326
                           && x.AccountTreeDetailsAccountTreeId != 21110105)
                         .Include(x => x.AccountTreeDetails).ToList();

            if (wazifi == null)
            {
                return Result<EmployeeDataInfoDto>.Failure(new Error("404", "الملف غير موجود"));
            }


            wazifi.ForEach(x => wazifiData.Add(
                new EmployeeDataDto()
                {
                    AccountTreeId = x.AccountTreeDetailsId,
                    AccountName = x.AccountTreeDetails.Name,
                    StartDate = x.StartDate,
                    Amount = x.Amount
                }
            ));

            var result = new EmployeeDataInfoDto();
            result.WazifiData = wazifiData;


            return Result<EmployeeDataInfoDto>.Success(result);
        }
    }
}