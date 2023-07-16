global using Domain.Models;
using Domain.IdentityModels;
using Domain.Interfaces.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace Persistence.Repositories
{
    public sealed class BankBranchRepository : GenericRepository<BankBranchModel>, IBankBranchRepository
    {
        public BankBranchRepository(AppDataContext context, UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor) : base(context, userManager, httpContextAccessor)
        {
        }
    }
}