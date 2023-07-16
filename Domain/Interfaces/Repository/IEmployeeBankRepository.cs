using Domain.Models;

namespace Domain.Interfaces.Repository
{
#nullable enable
    public interface IEmployeeBankRepository : IGenericRepository<EmployeeBankAccountModel>
    {
        EmployeeBankAccountModel? GetEmployeeBankAccount(int employeeId, int bankId);
    }
}
