
using Application.Common;
using Application.Common.Messaging;
using AutoMapper;
using Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.BankBranche.Queries.GetBankBranches
{
    public record GetBankBranchesListQuery(int param) : IQuery<List<BankBranchDto>>;

    public class GetBankBranchesListQueryHandler : IQueryHandler<GetBankBranchesListQuery, List<BankBranchDto>>
    {
        private readonly IUOW _uow;
        private readonly IMapper _mapper;

        public GetBankBranchesListQueryHandler(IUOW uow, IMapper mapper)
        {
            this._uow = uow;
            this._mapper = mapper;
        }

        public async Task<Result<List<BankBranchDto>>> Handle(GetBankBranchesListQuery request, CancellationToken cancellationToken)
        {

            var bankBranches = await _uow.BankBranchRepo.GetQueryable().Where(x => x.BankId == request.param).ToListAsync(cancellationToken);

            var bankBranchesToReturn = _mapper.Map<List<BankBranchDto>>(bankBranches);


            return bankBranchesToReturn;
        }
    }
}