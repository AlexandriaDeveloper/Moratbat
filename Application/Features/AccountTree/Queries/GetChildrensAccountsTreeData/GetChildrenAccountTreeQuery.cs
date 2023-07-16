
using Application.Common;
using Application.Common.Messaging;
using Application.Features.BudgetItems;
using AutoMapper;

namespace Application.Features.AccountTree.Queries.GetChildrensAccountTree
{
    public record GetChildrenAccountsTreeDataQuery(int ChildId) : IQuery<List<AccountTreeDetailsDto>>;
    public class GetChildrenAccountsTreeDataQueryHandler : IQueryHandler<GetChildrenAccountsTreeDataQuery, List<AccountTreeDetailsDto>>
    {
        private readonly IUOW _uow;
        private readonly IMapper _mapper;
        public GetChildrenAccountsTreeDataQueryHandler(IUOW uow, IMapper mapper)
        {
            this._mapper = mapper;
            this._uow = uow;

        }
        public async Task<Result<List<AccountTreeDetailsDto>>> Handle(GetChildrenAccountsTreeDataQuery request, CancellationToken cancellationToken)
        {
            var Childrens = this._uow.AccountTreeDetailsRepo.GetQueryable().Where(x => x.AccountTreeId == request.ChildId);
            var result = _mapper.Map<List<AccountTreeDetailsDto>>(Childrens);
            return Result<List<AccountTreeDto>>.Success(result);

        }
    }
}