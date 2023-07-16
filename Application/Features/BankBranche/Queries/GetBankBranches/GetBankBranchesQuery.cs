
using Application.Common;
using Application.Common.Messaging;
using AutoMapper;
using Domain.Interfaces.Repository;
using Persistence.Constants.Param;
using Persistence.Repositories;
using Persistence.Specifications.Bank;

namespace Application.Features.BankBranche.Queries.GetBankBranches
{
    public record GetBankBranchesQuery(BankBranchParam param) : IQuery<PaginatedResult<BankBranchDto>>;

    public class GetBankBranchesQueryHandler : IQueryHandler<GetBankBranchesQuery, PaginatedResult<BankBranchDto>>
    {
        private readonly IUOW _uow;
        private readonly IMapper _mapper;

        public GetBankBranchesQueryHandler(IUOW uow, IMapper mapper)
        {
            this._uow = uow;
            this._mapper = mapper;
        }

        public async Task<Result<PaginatedResult<BankBranchDto>>> Handle(GetBankBranchesQuery request, CancellationToken cancellationToken)
        {
            var specs = new BankBranchSpecs(request.param);

            var bankBranches = await _uow.BankBranchRepo.GetPagedBySpecificationAsync(specs, request.param.pageIndex, request.param.pageSize);
            var bankBranchesToReturn = _mapper.Map<List<BankBranchDto>>(bankBranches.Records);


            return new PaginatedResult<BankBranchDto>(bankBranches.PageIndex, bankBranches.PageSize, bankBranches.TotalRecords, bankBranchesToReturn);
        }
    }
}