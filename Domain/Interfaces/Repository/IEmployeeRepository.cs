using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repository
{
    public interface IEmployeeRepository : IGenericRepository<EmployeeModel>
    {
        Task InsertEmployees(List<EmployeeModel> employees);
    }
}