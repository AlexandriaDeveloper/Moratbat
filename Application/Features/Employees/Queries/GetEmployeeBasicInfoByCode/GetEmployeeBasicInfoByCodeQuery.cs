
using Application.Common;
using Application.Common.Messaging;
using Application.Features.Employees.Queries.GetEmployees;
using AutoMapper;
using Domain;
using Domain.Interfaces.Repository;
using Persistence.Specifications;

namespace Application.Features.Employees.Queries.GetEmployeeBasicInfoByCode
{


    public record GetEmployeeBasicInfoByCodeQuery(EmployeeByCodeRequest request) : IQuery<EmployeeDto>;
    public class GetEmployeeBasicInfoByCodeQueryHandler : IQueryHandler<GetEmployeeBasicInfoByCodeQuery, EmployeeDto>
    {
        private readonly IUOW _uow;
        private readonly IMapper _mapper;

        public GetEmployeeBasicInfoByCodeQueryHandler(IUOW uow, IMapper mapper)
        {
            this._uow = uow;
            this._mapper = mapper;
        }
        public async Task<Result<EmployeeDto>> Handle(GetEmployeeBasicInfoByCodeQuery request, CancellationToken cancellationToken)
        {
            var spec = new GetEmployeeBasicInfoSpecification();

            if (request.request.SearchBy == "tabCode")
            {
                spec.Criteries.Add(x => x.TabCode == request.request.Code);
            }
            if (request.request.SearchBy == "tegaraCode")
            {
                spec.Criteries.Add(x => x.TegaraCode == request.request.Code);
            }
            EmployeeModel employee = await _uow.EmployeeRepo.GetByWithSpecAsync(spec);

            if (employee == null)
            {
                return Result.Failure<EmployeeDto>(new Error("404", "عفوا الموظف غير موجود بقاعدة البيانات "));
            }
            EmployeeDto employeeToReturn = _mapper.Map<EmployeeDto>(employee);
            return Result<EmployeeDto>.Success(employeeToReturn);
        }
    }

    public class EmployeeByCodeRequest
    {
        public string Code { get; set; }
        public string SearchBy { get; set; }
    }
}