using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repository
{
    public interface IUOW : IDisposable
    {
        IEmployeeRepository EmployeeRepo { get; }
        IEmployeeGradeRepository EmployeeGradeRepo { get; }
        IGradeRepository GradeRepo { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}