using Domain.Interfaces.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace Persistence.Repositories
{
    public sealed class EmployeeBasicFinancialDataRepository : GenericRepository<EmployeeBasicFinancialDataModel>, IEmployeeBasicFinancialDataRepository
    {
        public EmployeeBasicFinancialDataRepository(AppDataContext context, UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor) : base(context, userManager, httpContextAccessor)
        {
        }
    }
}