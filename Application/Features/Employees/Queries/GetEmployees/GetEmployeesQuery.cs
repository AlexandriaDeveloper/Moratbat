
using Application.Common;
using Application.Common.Messaging;
using AutoMapper;
using Domain.Interfaces.Repository;
using Persistence.Constants.Param;
using Persistence.Repositories;
using Persistence.Specifications;

namespace Application.Features.Employees.Queries.GetEmployees
{
    public record GetEmployeesQuery(EmployeeParam param) : IQuery<PaginatedResult<EmployeeDto>>;

    public class GetEmployeesQueryHandler : IQueryHandler<GetEmployeesQuery, PaginatedResult<EmployeeDto>>
    {
        private readonly IMapper _mapper;

        public IUOW _uow { get; }
        public GetEmployeesQueryHandler(IUOW uow, IMapper mapper)
        {
            this._uow = uow;
            this._mapper = mapper;
        }

        public async Task<Result<PaginatedResult<EmployeeDto>>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
        {
            var spec = new EmployeeSpecification(request.param);
            var employeesToReturn = await _uow.EmployeeRepo.GetPagedBySpecificationAsync(spec, request.param.pageIndex, request.param.pageSize);
            var dataToReturn = _mapper.Map<List<EmployeeDto>>(employeesToReturn.Records);
            return new PaginatedResult<EmployeeDto>(employeesToReturn.PageIndex, employeesToReturn.PageSize, employeesToReturn.TotalRecords, dataToReturn);
        }
    }

}