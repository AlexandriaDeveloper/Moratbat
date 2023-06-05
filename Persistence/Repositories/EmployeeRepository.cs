using System.Security.Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.IdentityModels;
using Domain.Interfaces.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace Persistence.Repositories
{
    public sealed class EmployeeRepository : GenericRepository<EmployeeModel>, IEmployeeRepository
    {



        public async Task InsertEmployees(List<EmployeeModel> employees)
        {
            //E var empId = _accessor.HttpContext.User.FindFirstValue("UUID");
            foreach (var emp in employees)
            {
                emp.CreatedBy = UUID;
                emp.CteaedAt = DateTime.UtcNow.ToLocalTime();
            }
            await _context.AddRangeAsync(employees);
        }

        public EmployeeRepository(AppDataContext context, UserManager<AppUser> userManager, IHttpContextAccessor accessor) : base(context, userManager, accessor)
        {


        }
      
    }

    

}