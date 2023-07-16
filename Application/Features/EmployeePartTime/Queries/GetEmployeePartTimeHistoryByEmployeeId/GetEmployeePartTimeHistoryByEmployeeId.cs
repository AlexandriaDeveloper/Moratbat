using Application.Common;
using Application.Common.Messaging;
using Application.Features.EmployeePartTime.Commands.AddPartTimeToEmployee;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.EmployeePartTime.Queries.GetEmployeePartTimeHistoryByEmployeeId
{
    public record GetEmployeePartTimeHistoryByEmployeeIdQuery(int employeeId) : IQuery<List<EmployeePartTimeDto>>;
    public class GetEmployeePartTimeHistoryByEmployeeIdQueryHandler : IQueryHandler<GetEmployeePartTimeHistoryByEmployeeIdQuery, List<EmployeePartTimeDto>>
    {
        private readonly IUOW _uOW;
        private readonly IMapper _mapper;
        public GetEmployeePartTimeHistoryByEmployeeIdQueryHandler(IUOW uOW, IMapper mapper)
        {
            this._mapper = mapper;
            this._uOW = uOW;

        }
        public async Task<Result<List<EmployeePartTimeDto>>> Handle(GetEmployeePartTimeHistoryByEmployeeIdQuery request, CancellationToken cancellationToken)
        {
            var employeePartTime = await _uOW.EmployeePartTimeRepo.GetQueryable().Where(x => x.EmployeeId == request.employeeId).ToListAsync(cancellationToken);
            return Result<List<EmployeePartTimeDto>>.Success(_mapper.Map<List<EmployeePartTimeDto>>(employeePartTime));

        }
    }
}