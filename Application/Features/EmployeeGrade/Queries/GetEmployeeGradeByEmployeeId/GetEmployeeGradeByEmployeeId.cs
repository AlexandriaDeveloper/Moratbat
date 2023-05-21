using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Common;
using Application.Common.Messaging;
using AutoMapper;
using Domain.Interfaces.Repository;
using Persistence.Constants;
using Persistence.Specifications.EmployeeGradeSpecs;

namespace Application.Features.EmployeeGrade.Queries.GetEmployeeGradeByEmployeeId
{
    public record GetEmployeeGradeByEmployeeIdQuery(EmployeeGradeParam employee) : IQuery<EmployeeGradeDto>;
    public class GetEmployeeGradeByEmployeeIdQueryHandler : IQueryHandler<GetEmployeeGradeByEmployeeIdQuery, EmployeeGradeDto>
    {
        private readonly IUOW _uow;
        private readonly IMapper _mapper;

        public GetEmployeeGradeByEmployeeIdQueryHandler(IUOW uow, IMapper mapper)
        {
            this._uow = uow;
            this._mapper = mapper;
        }
        public async Task<Result<EmployeeGradeDto>> Handle(GetEmployeeGradeByEmployeeIdQuery request, CancellationToken cancellationToken)
        {
            var spec = new EmployeeGradeSpecification(new Persistence.Constants.EmployeeGradeParam() { EmployeeId = request.employee.EmployeeId, EndAt = null });
            spec.Includes.Add(x => x.Grade);
            spec.Includes.Add(x => x.Grade.Parent);
            spec.Includes.Add(x => x.Grade.Parent.Parent);
            var empGrade = await _uow.EmployeeGradeRepo.GetByWithSpecAsync(spec);
            if (empGrade == null)
            {
                return Result<EmployeeGradeDto>.Failure(new Error("404", "الموظف غير مسجل به اى درجة "));
            }
            var empGradeToReturn = _mapper.Map<EmployeeGradeDto>(empGrade);
            return Result<EmployeeGradeDto>.Success(empGradeToReturn);
        }
    }


}