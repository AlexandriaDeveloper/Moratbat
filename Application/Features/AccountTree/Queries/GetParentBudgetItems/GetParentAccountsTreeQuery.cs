using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Common;
using Application.Common.Messaging;
using Application.Features.BudgetItems;
using AutoMapper;
using Domain.Constants;

namespace Application.Features.AccountTree.Queries.GetParentAccountTree
{
    public record GetParentAccountsTreeQuery() : IQuery<List<AccountTreeDto>>;
    public class GetParentBudgetItemsQueryHandler : IQueryHandler<GetParentAccountsTreeQuery, List<AccountTreeDto>>
    {
        private readonly IUOW _uow;
        private readonly IMapper _mapper;
        public GetParentBudgetItemsQueryHandler(IUOW uow, IMapper mapper)
        {
            this._mapper = mapper;
            this._uow = uow;

        }
        public async Task<Result<List<AccountTreeDto>>> Handle(GetParentAccountsTreeQuery request, CancellationToken cancellationToken)
        {

            var ParentBudgetItems = this._uow.AccountTreeRepo.GetQueryable().Where(x => x.AccountParentId == null);
            var result = _mapper.Map<List<AccountTreeDto>>(ParentBudgetItems);
            return Result<List<AccountTreeDto>>.Success(result);
            throw new NotImplementedException();
        }
    }
}