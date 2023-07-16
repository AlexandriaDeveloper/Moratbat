using System.Transactions;
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
        private ICollectionRepository _collectionRepository;
        private IEmployeeCollectionRepository _employeeCollectionRepository;
        private IEmployeeBankRepository _employeeBankRepository;
        private IEmployeePartTimeRepository _employeePartTimeRepository;
        private IBankRepository _bankRepository;
        private IBankBranchRepository _bankBranchRepository;
        private IEmployeeGradeRepository _employeeGradeRepository;
        private IEmployeeBasicFinancialDataRepository _employeeBasicFinancialDataRepository;
        private IGradeRepository _gradeRepository;
        private IAccountTreeRepository _accountTreeRepository;
        private IAccountTreeDetailsRepository _accountTreeDetailRepository;
        //internal GenericRepository<EmployeeModel> EmployeeRepo => _employeeRepository ?? new EmployeeRepository(_context, _userManager);

        public IEmployeeRepository EmployeeRepo => _employeeRepository ?? new EmployeeRepository(_context, _userManager, _accessor);
        public ICollectionRepository CollectionRepo => _collectionRepository ?? new CollectionRepository(_context, _userManager, _accessor);
        public IEmployeeCollectionRepository EmployeeCollectionRepo => _employeeCollectionRepository ?? new EmployeeCollectionRepository(_context, _userManager, _accessor);
        public IBankRepository BankRepo => _bankRepository ?? new BankRepository(_context, _userManager, _accessor);
        public IBankBranchRepository BankBranchRepo => _bankBranchRepository ?? new BankBranchRepository(_context, _userManager, _accessor);
        public IEmployeeBankRepository EmployeeBankRepo => _employeeBankRepository ?? new EmployeeBankRepository(_context, _userManager, _accessor);
        public IEmployeePartTimeRepository EmployeePartTimeRepo => _employeePartTimeRepository ?? new EmployeePartTimeRepository(_context, _userManager, _accessor);
        public IEmployeeGradeRepository EmployeeGradeRepo => _employeeGradeRepository ?? new EmployeeGradeRepository(_context, _userManager, _accessor);
        public IEmployeeBasicFinancialDataRepository EmployeeBasicFinancialDataRepo => _employeeBasicFinancialDataRepository ?? new EmployeeBasicFinancialDataRepository(_context, _userManager, _accessor);
        public IGradeRepository GradeRepo => _gradeRepository ?? new GradeRepository(_context, _userManager, _accessor);
        public IAccountTreeRepository AccountTreeRepo => _accountTreeRepository ?? new AccountTreeRepository(_context, _userManager, _accessor);
        public IAccountTreeDetailsRepository AccountTreeDetailsRepo => _accountTreeDetailRepository ?? new AccountTreeDetailRepository(_context, _userManager, _accessor);


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

                using var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
                await _context.SaveChangesAsync(cancellationToken);
                transactionScope.Complete();

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