

using Application.Common;
using Application.Common.Messaging;

namespace Application.Features.AccountTree.Queries.GetMaxAccountTreeDetailsId
{
    public record GetMaxAccountTreeDetailsIdQuery(int AccountTreeId) : ICommand<int>;
    public class GetMaxAccountTreeDetailsIdQueryHandler : ICommandHandler<GetMaxAccountTreeDetailsIdQuery, int>
    {
        private readonly IUOW _uow;
        public GetMaxAccountTreeDetailsIdQueryHandler(IUOW uow)
        {
            this._uow = uow;

        }
        public Task<Result<int>> Handle(GetMaxAccountTreeDetailsIdQuery request, CancellationToken cancellationToken)
        {
            int result = 0;
            var accounts = _uow.AccountTreeDetailsRepo.GetQueryable().Where(x => x.AccountTreeId == request.AccountTreeId);
            if (!accounts.Any())
            {
                return Task.FromResult(Result<int>.Success(result + 1));
            }
            result = accounts.Max(x => x.Id);
            return Task.FromResult(Result<int>.Success(result + 1));
        }
    }
}