using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    [Table("Department")]
    public class DepartmentModel : BaseEntityModel
    {
        public ICollection<EmployeeDepartmentModel>? Employees { get; set; }
    }
}