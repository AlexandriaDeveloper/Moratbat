
using Application.Common;
using Application.Common.Messaging;
using AutoMapper;
using Persistence.Constants.Param;
using Persistence.Repositories;

namespace Application.Features.Collection.Queries.GetCollictions
{
    public record GetCollictionsQuery(CollectionParam param) : IQuery<PaginatedResult<CollectionDto>>;
    public class GetCollictionsQueryHandler : IQueryHandler<GetCollictionsQuery, PaginatedResult<CollectionDto>>
    {
        private readonly IUOW _uOW;
        private readonly IMapper _mapper;
        public GetCollictionsQueryHandler(IUOW uOW, IMapper mapper)
        {
            this._mapper = mapper;
            this._uOW = uOW;

        }
        public async Task<Result<PaginatedResult<CollectionDto>>> Handle(GetCollictionsQuery request, CancellationToken cancellationToken)
        {
            var spec = new CollectionListSpec(request.param);
            var result = await _uOW.CollectionRepo.GetPagedBySpecificationAsync(spec, request.param.pageIndex, request.param.pageSize);

            return new PaginatedResult<CollectionDto>(request.param.pageIndex, request.param.pageSize, result.TotalRecords, _mapper.Map<List<CollectionDto>>(result.Records));
        }
    }
}