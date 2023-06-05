using Domain.IdentityModels;
using Domain.Interfaces.Repository;
using EntityFramework.Exceptions.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Persistence.Repositories
{
#nullable enable
    public class UOW : IUOW
    {
        private readonly AppDataContext _context;

        private IEmployeeRepository _employeeRepository;
        private IEmployeeBankRepository _employeeBankRepository;
        private IBankRepository _bankRepository;
        private IBankBranchRepository _bankBranchRepository;
        private IEmployeeGradeRepository _employeeGradeRepository;
        private IGradeRepository _gradeRepository;
        //internal GenericRepository<EmployeeModel> EmployeeRepo => _employeeRepository ?? new EmployeeRepository(_context, _userManager);

        public IEmployeeRepository EmployeeRepo => _employeeRepository ?? new EmployeeRepository(_context, _userManager, _accessor);
        public IBankRepository BankRepo => _bankRepository ?? new BankRepository(_context, _userManager, _accessor);
        public IBankBranchRepository BankBranchRepo => _bankBranchRepository ?? new BankBranchRepository(_context, _userManager, _accessor);
        public IEmployeeBankRepository EmployeeBankRepo => _employeeBankRepository ?? new EmployeeBankRepository(_context, _userManager, _accessor);
        public IEmployeeGradeRepository EmployeeGradeRepo => _employeeGradeRepository ?? new EmployeeGradeRepository(_context, _userManager, _accessor);
        public IGradeRepository GradeRepo => _gradeRepository ?? new GradeRepository(_context, _userManager, _accessor);



        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _accessor;
        private readonly ILogger<UOW> _logger;

        public UOW(AppDataContext context, UserManager<AppUser> userManager, IHttpContextAccessor accessor, ILogger<UOW> logger)
        {
            this._userManager = userManager;
            this._accessor = accessor;
            this._logger = logger;
            this._context = context;

        }

        public async Task<SaveChangesAsyncResult> SaveChangesAsync(CancellationToken cancellationToken)
        {

            try
            {
                await _context.SaveChangesAsync(cancellationToken);

            }
            catch (UniqueConstraintException)
            {
                return new SaveChangesAsyncResult().RaiseError("0000", "عفوا البيان مسجل من قبل لا يمكن التكرار");
            }
            catch (System.Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return new SaveChangesAsyncResult().RaiseError("000", ex.Message);

            }



            return new SaveChangesAsyncResult().SavedSuccessfuly();

        }

    }


}