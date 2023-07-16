using Application.Common;
using Application.Common.Messaging;
using Application.Features.EmployeeBasicFinancialData.UploadEmployeeBasicFinancialData;
using AutoMapper;
using NPOI.SS.Formula.Functions;
using static Application.Features.EmployeeBasicFinancialData.UploadEmployeeBasicFinancialData.EmployeeBasicSallaryInfoDto;

namespace Application.Features.EmployeeBasicFinancialData.Queries.GetEmployeeWazifi
{
    public record GetEmployeeBasicSallaryInfoQuery(int employeeId, DateTime peekDate) : IQuery<List<Data>>;
    public class GetEmployeeBasicSallaryInfoQueryHandler : IQueryHandler<GetEmployeeBasicSallaryInfoQuery, List<Data>>
    {
        private readonly IUOW _uow;
        private readonly IMapper _mapper;
        public GetEmployeeBasicSallaryInfoQueryHandler(IUOW uow, IMapper mapper)
        {
            this._mapper = mapper;
            this._uow = uow;

        }
        public async Task<Result<List<Data>>> Handle(GetEmployeeBasicSallaryInfoQuery request, CancellationToken cancellationToken)
        {

            var employee = await _uow.EmployeeRepo.GetByIdAsync(request.employeeId);
            if (employee == null)
            {
                return Result<List<Data>>.Failure(new Error("404", "الموظف غير موجود"));
            }


            var employeeAccountTree = _uow.EmployeeBasicFinancialDataRepo.GetQueryable()
             .Where(x => x.EmployeeId == request.employeeId
              && x.StartDate <= request.peekDate)
             .GroupBy(x => x.AccountTreeDetailsAccountTreeId)
             .Select(t => new
             {
                 AccountTreeId = t.Key,
                 AccountName = t.FirstOrDefault().AccountTreeDetails.AccountTree.Name,
                 Amount = t.Sum(x => x.Amount)
             }).ToList();


            var dataToReturn = new List<Data>();
            if (employee.Qanon == Domain.Constants.QanonEnum.Qanon81)
            {
                var wazifi = employeeAccountTree.FirstOrDefault(x => x.AccountTreeId == 21110105).Amount;
                var mokamel = employeeAccountTree.Where(x => x.AccountTreeId != 21110105 && x.AccountTreeId != 21110326).Sum(x => x.Amount);
                var tawidi = employeeAccountTree.FirstOrDefault(x => x.AccountTreeId == 21110326).Amount;
                var result = new EmployeeBasicSallaryInfoDto();
                dataToReturn = result.SetQanon81(wazifi, mokamel, tawidi);

            }

            if (employee.Qanon == Domain.Constants.QanonEnum.Qanon49)
            {
                var asasi = employeeAccountTree.FirstOrDefault(x => x.AccountTreeId == 21110101).Amount;
                var mokamel = employeeAccountTree.Where(x => x.AccountTreeId != 21110105 && x.AccountTreeId != 21110326).Sum(x => x.Amount);
                var tawidi = employeeAccountTree.FirstOrDefault(x => x.AccountTreeId == 21110326).Amount;
                // var result = new EmployeeBasicSallaryInfoDto().SetQanon49(asasi, null, null);
                new NotImplementedException();
            }
            return Result<EmployeeBasicSallaryInfoDto>.Success(dataToReturn);


        }
    }


}