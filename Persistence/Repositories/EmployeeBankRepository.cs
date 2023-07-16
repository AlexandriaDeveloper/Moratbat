using Domain;
using Domain.IdentityModels;
using Domain.Interfaces.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace Persistence.Repositories
{
    public sealed class EmployeeBankRepository : GenericRepository<EmployeeBankAccountModel>, IEmployeeBankRepository
    {
        public EmployeeBankRepository(AppDataContext context, UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor) : base(context, userManager, httpContextAccessor)
        {
        }

        public EmployeeBankAccountModel? GetEmployeeBankAccount(int employeeId, int bankId)
        {
            EmployeeModel emp = _context.Employees.Where(x => x.Id == employeeId)
            .Include(x => x.BankAccount).FirstOrDefault();

            if (emp != null)
            {
                return emp.BankAccount;
            }

            return null;

        }
    }
}