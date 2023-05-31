using Application.Common;
using Application.Common.Messaging;
using AutoMapper;
using Domain.Interfaces.Repository;

namespace Application.Features.Grade.Queries.GetGradeById
{
    public record GetGradeByIdQuery(int gradeId) : IQuery<GradeDto>;
    public class GetGradeByIdQueryHandler : IQueryHandler<GetGradeByIdQuery, GradeDto>
    {
        private readonly IUOW _uow;
        private readonly IMapper _mapper;
        public GetGradeByIdQueryHandler(IUOW uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<Result<GradeDto>> Handle(GetGradeByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _uow.GradeRepo.GetByIdAsync(request.gradeId);
            if (result == null)
            {
                return Result<GradeDto>.Failure(new Error("404", "عفوا غير موجود "));
            }
            var gradeToReturn = _mapper.Map<GradeDto>(result);
            return Result<GradeDto>.Success(gradeToReturn);
        }
    }
}