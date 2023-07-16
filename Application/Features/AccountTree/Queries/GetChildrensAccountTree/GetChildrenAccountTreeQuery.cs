
using Application.Common;
using Application.Common.Messaging;
using Application.Features.BudgetItems;
using AutoMapper;

namespace Application.Features.AccountTree.Queries.GetChildrensAccountTree
{
    public record GetChildrenAccountsTreeQuery(int parentId) : IQuery<List<AccountTreeDto>>;
    public class GetChildrenAccountsTreeQueryHandler : IQueryHandler<GetChildrenAccountsTreeQuery, List<AccountTreeDto>>
    {
        private readonly IUOW _uow;
        private readonly IMapper _mapper;
        public GetChildrenAccountsTreeQueryHandler(IUOW uow, IMapper mapper)
        {
            this._mapper = mapper;
            this._uow = uow;

        }
        public async Task<Result<List<AccountTreeDto>>> Handle(GetChildrenAccountsTreeQuery request, CancellationToken cancellationToken)
        {
            var Childrens = this._uow.AccountTreeRepo.GetQueryable().Where(x => x.AccountParentId == request.parentId);
            var result = _mapper.Map<List<AccountTreeDto>>(Childrens);
            return Result<List<AccountTreeDto>>.Success(result);

        }
    }
}