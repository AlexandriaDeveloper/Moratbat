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
    public record GetBankListQuery() : IQuery<List<BankDto>>;

    public class GetBankListQueryHandler : IQueryHandler<GetBankListQuery, List<BankDto>>
    {
        private readonly IUOW _uow;
        private readonly IMapper _mapper;

        public GetBankListQueryHandler(IUOW uow, IMapper mapper)
        {
            this._uow = uow;
            this._mapper = mapper;
        }

        public async Task<Result<List<BankDto>>> Handle(GetBankListQuery request, CancellationToken cancellationToken)
        {
            var banks = await _uow.BankRepo.GetAllAsync();
            var dataToReturn = _mapper.Map<List<BankDto>>(banks);


            return dataToReturn;
        }
    }


}