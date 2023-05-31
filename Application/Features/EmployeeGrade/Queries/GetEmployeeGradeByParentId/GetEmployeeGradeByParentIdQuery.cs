using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Common;
using Application.Common.Messaging;
using Application.Features.Grade.Queries.GetGradeById;
using AutoMapper;
using Domain.Interfaces.Repository;
using Persistence.Constants;
using Persistence.Specifications.EmployeeGradeSpecs;
using Persistence.Specifications.GradeSpecs;

namespace Application.Features.EmployeeGrade.Queries.GetEmployeeGradeByParentId
{
    public record GetGradesByParentIdQuery(int? id) : IQuery<List<GradeDto>>;
    public class GetGradesByParentIdQueryHandler : IQueryHandler<GetGradesByParentIdQuery, List<GradeDto>>
    {
        private readonly IUOW _uow;
        private readonly IMapper _mapper;

        public GetGradesByParentIdQueryHandler(IUOW uow, IMapper mapper)
        {
            this._uow = uow;
            this._mapper = mapper;
        }
        public async Task<Result<List<GradeDto>>> Handle(GetGradesByParentIdQuery request, CancellationToken cancellationToken)
        {
            GradeParam param = new GradeParam();
            if (request.id.HasValue)
            {
                param.OnlyParent = false;
                param.ParentId = request.id;
            }

            var spec = new GradeSpecificaions(param);
            var gradesFromDb = await _uow.GradeRepo.GetAllWithSpecAsync(spec);
            if (gradesFromDb == null)
            {
                return Result<List<GradeDto>>.Failure(new Error("404", "عفوا لم نجد الدرجات المطلوبه"));
            }
            var gradesToReturn = _mapper.Map<List<GradeDto>>(gradesFromDb);
            return Result<List<GradeDto>>.Success(gradesToReturn);
        }
    }
}