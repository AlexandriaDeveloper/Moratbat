using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repository
{
    public interface IUOW
    {
        IEmployeeRepository EmployeeRepo { get; }
        IEmployeeGradeRepository EmployeeGradeRepo { get; }
        IEmployeeBankRepository EmployeeBankRepo { get; }
        IEmployeePartTimeRepository EmployeePartTimeRepo { get; }
        IEmployeeBasicFinancialDataRepository EmployeeBasicFinancialDataRepo { get; }
        IBankRepository BankRepo { get; }
        ICollectionRepository CollectionRepo { get; }
        IEmployeeCollectionRepository EmployeeCollectionRepo { get; }
        IBankBranchRepository BankBranchRepo { get; }
        IGradeRepository GradeRepo { get; }
        IAccountTreeRepository AccountTreeRepo { get; }
        IAccountTreeDetailsRepository AccountTreeDetailsRepo { get; }
        Task<SaveChangesAsyncResult> SaveChangesAsync(CancellationToken cancellationToken);
    }

    public class SaveChangesAsyncResult
    {


        public SaveChangesAsyncResult SavedSuccessfuly()
        {
            this.IsSuccess = true;
            this.IsFailure = false;
            this.Message = " تم الحفظ بنجاح";
            return this;
        }
        public SaveChangesAsyncResult RaiseError(string ErrorCode, string Message)
        {
            this.IsSuccess = false;
            this.IsFailure = true;
            this.ErrorCode = ErrorCode;
            this.Message = Message;
            return this;
        }
        public bool IsSuccess { get; set; }
        public bool IsFailure { get; set; }
        public string ErrorCode { get; set; }
        public string Message { get; set; }
    }
}