
using Application.Common;
using Application.Common.Messaging;
using Application.Features.Collection.Queries.GetEmployeesInCollection;
using Application.Features.EmployeeCollection.Commands.AddEmployeeToCollection;
using Application.Features.Employees.Queries.GetEmployees;
using AutoMapper;
using Persistence.Constants.Param;
using Persistence.Repositories;

namespace Application.Features.EmployeeCollection.Queries.GetEmployeesInCollection
{
    public record GetEmployeesInCollectionQuery(int id, EmployeeInCollectionParam param) : IQuery<PaginatedResult<EmployeeInCollectionDto>>;
    public class GetEmployeesInCollectionQueryHandler : IQueryHandler<GetEmployeesInCollectionQuery, PaginatedResult<EmployeeInCollectionDto>>
    {
        private readonly IUOW _uOW;
        private readonly IMapper _mapper;

        public GetEmployeesInCollectionQueryHandler(IUOW uOW, IMapper mapper)
        {
            this._mapper = mapper;
            this._uOW = uOW;

        }
        public async Task<Result<PaginatedResult<EmployeeInCollectionDto>>> Handle(GetEmployeesInCollectionQuery request, CancellationToken cancellationToken)
        {
            var spec = new GetEmployeesInCollectionQuerySpec(request.id, request.param);
            var employeesInSpec = await _uOW.EmployeeCollectionRepo.GetPagedBySpecificationAsync(spec, request.param.pageIndex, request.param.pageSize);

            return new PaginatedResult<EmployeeInCollectionDto>(request.param.pageIndex, request.param.pageSize, employeesInSpec.TotalRecords, _mapper.Map<List<EmployeeInCollectionDto>>(employeesInSpec.Records));
        }

    }
}