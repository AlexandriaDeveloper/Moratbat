using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Common;
using Application.Common.Messaging;
using Application.Features.Employees.Queries.GetEmployees;
using AutoMapper;
using Domain;
using Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using Persistence.Specifications;

namespace Application.Features.Employees.Queries.GetEmployeeBasicInfo
{
    public record GetEmployeeBasicInfoQuery(int employeeId) : IQuery<EmployeeDto>;
    public class GetEmployeeBasicInfoQueryHandler : IQueryHandler<GetEmployeeBasicInfoQuery, EmployeeDto>
    {
        private readonly IUOW _uow;
        private readonly IMapper _mapper;

        public GetEmployeeBasicInfoQueryHandler(IUOW uow, IMapper mapper)
        {
            this._uow = uow;
            this._mapper = mapper;
        }
        public async Task<Result<EmployeeDto>> Handle(GetEmployeeBasicInfoQuery request, CancellationToken cancellationToken)
        {
            var spec = new GetEmployeeBasicInfoSpecification();
            spec.Criteries.Add(x => x.Id == request.employeeId);
            EmployeeModel employee = await _uow.EmployeeRepo.GetByWithSpecAsync(spec);
            if (employee == null)
            {
                return Result.Failure<EmployeeDto>(new Error("404", "عفوا الموظف غير موجود بقاعدة البيانات "));
            }
            EmployeeDto employeeToReturn = _mapper.Map<EmployeeDto>(employee);
            return Result<EmployeeDto>.Success(employeeToReturn);
        }
    }
}