using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
#nullable enable
    [Table("Department")]
    public class DepartmentModel : BaseEntityModel
    {
        public ICollection<EmployeeDepartmentModel>? Employees { get; set; }
    }
}