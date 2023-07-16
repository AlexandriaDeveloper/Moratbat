using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("EmployeeDepartment")]
    public class EmployeeDepartmentModel : BaseEntityModel
    {
        [NotMapped]
        public override int Id { get => base.Id; set => base.Id = value; }
        [NotMapped]
        public override string Name { get => base.Name; set => base.Name = value; }
        [Required]
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        [Key]
        public int DepartmentId { get; set; }
        public DateTime StartFrom { get; set; }
        public DateTime? EndAt { get; set; }
        public bool IsActive => EndAt == null;
        public EmployeeModel Employee { get; set; }
        public DepartmentModel Department { get; set; }
    }
}