using Application.Common;
using Application.Common.Messaging;
using AutoMapper;
using Domain.Interfaces.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Persistence.Constants.Param;
using Persistence.Repositories;
using Persistence.Specifications.Bank;

namespace Application.Features.Bank.Queries.GetBanks
{
    public record GetBanksQuery(BankParam Param) : IQuery<PaginatedResult<BankDto>>;

    public class GetBanksQueryHandler : IQueryHandler<GetBanksQuery, PaginatedResult<BankDto>>
    {
        private readonly IUOW _uow;
        private readonly IMapper _mapper;

        public GetBanksQueryHandler(IUOW uow, IMapper mapper)
        {
            this._uow = uow;
            this._mapper = mapper;
        }

        public async Task<Result<PaginatedResult<BankDto>>> Handle(GetBanksQuery request, CancellationToken cancellationToken)
        {
            var spec = new BankSpecificaions(request.Param);

            var banks = await _uow.BankRepo.GetPagedBySpecificationAsync(spec, request.Param.pageIndex, request.Param.pageSize);
            var dataToReturn = _mapper.Map<List<BankDto>>(banks.Records);

            foreach (BankDto branch in dataToReturn)
            {

                branch.BranchesCount = await _uow.BankBranchRepo.GetQueryable().Where(x => x.BankId == branch.Id).CountAsync();
            }
            return new PaginatedResult<BankDto>(banks.PageIndex, banks.PageSize, banks.TotalRecords, dataToReturn);//Result<List<BankDto>>.Success(_mapper.Map<List<BankDto>>(banks));
        }
    }


}