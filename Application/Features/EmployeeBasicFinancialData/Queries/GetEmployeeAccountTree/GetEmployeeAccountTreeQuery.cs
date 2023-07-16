using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Common;
using Application.Common.Messaging;
using AutoMapper;
using NPOI.SS.Formula.Functions;

namespace Application.Features.EmployeeBasicFinancialData.Queries.GetEmployeeAccountTree
{
    public record GetEmployeeAccountTreeQuery(int employeeId, DateTime peekDate) : IQuery<object>;
    public class GetEmployeeAccountTreeQueryHandler : IQueryHandler<GetEmployeeAccountTreeQuery, object>
    {
        private readonly IMapper _mapper;
        private readonly IUOW _uow;
        public GetEmployeeAccountTreeQueryHandler(IUOW uow, IMapper mapper)
        {
            this._uow = uow;
            this._mapper = mapper;

        }
        public async Task<Result<object>> Handle(GetEmployeeAccountTreeQuery request, CancellationToken cancellationToken)
        {
            var employeeAccountTree = _uow.EmployeeBasicFinancialDataRepo.GetQueryable()
            .Where(x => x.EmployeeId == request.employeeId
             && x.StartDate <= request.peekDate)
            .GroupBy(x => x.AccountTreeDetailsAccountTreeId)
            .Select(t => new
            {
                AccountTreeId = t.Key,
                AccountName = t.FirstOrDefault().AccountTreeDetails.AccountTree.Name,
                Amount = t.Sum(x => x.Amount)
            });
            return Task.FromResult(Result<object>.Success(employeeAccountTree));
        }
    }
}