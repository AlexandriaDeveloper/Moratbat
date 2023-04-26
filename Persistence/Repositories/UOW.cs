using Domain;
using Domain.IdentityModels;
using Domain.Interfaces.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Persistence.Repositories
{
    public class UOW : IUOW
    {
        private readonly AppDataContext _context;

        private IEmployeeRepository _employeeRepository;
        //internal GenericRepository<EmployeeModel> EmployeeRepo => _employeeRepository ?? new EmployeeRepository(_context, _userManager);

        public IEmployeeRepository EmployeeRepo => _employeeRepository ?? new EmployeeRepository(_context, _userManager, _accessor);



        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _accessor;

        public UOW(AppDataContext context, UserManager<AppUser> userManager, IHttpContextAccessor accessor)
        {
            this._userManager = userManager;
            this._accessor = accessor;
            this._context = context;

        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}