

using Domain.Models;

namespace Domain.Interfaces.Repository
{
    public interface IEmployeeRepository : IGenericRepository<EmployeeModel>
    {
        Task InsertEmployees(List<EmployeeModel> employees);
    }
}
