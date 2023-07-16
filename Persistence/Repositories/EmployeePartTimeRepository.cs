using Domain.Interfaces.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace Persistence.Repositories
{
    public sealed class EmployeePartTimeRepository : GenericRepository<EmployeePartTimeModel>, IEmployeePartTimeRepository
    {
        public EmployeePartTimeRepository(AppDataContext context, UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor) : base(context, userManager, httpContextAccessor)
        {
        }


    }
}