using Application.Common;
using Application.Common.Messaging;
using AutoMapper;
using Domain.Interfaces.Repository;
using Persistence.Constants.Param;
using Persistence.Specifications.Bank;

namespace Application.Features.Bank.Queries.GetBanks
{
    public record GetBankByQuery(BankParam Param) :IQuery<BankDto>;
       public class GetBankByQueryHandler : IQueryHandler<GetBankByQuery, BankDto>
    {
        private readonly IUOW _uow;
        private readonly IMapper _mapper;

        public GetBankByQueryHandler(IUOW uow , IMapper mapper )
        {
            this._uow = uow;
            this._mapper = mapper;
        }
       
        public async Task<Result<BankDto>> Handle(GetBankByQuery request, CancellationToken cancellationToken)
        {
            var spec = new BankSpecificaions(request.Param);
            var banks = await _uow.BankRepo.GetByWithSpecAsync(spec);   

            return Result<BankDto>.Success(_mapper.Map<BankDto>(banks));
        }
    }
}