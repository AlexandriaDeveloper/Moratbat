using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Constants;

namespace Domain.Models
{
#nullable enable
    [Table("Employee")]
    public class EmployeeModel : BaseEntityModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public override int Id { get; set; }

        [MaxLength(5)]
        public string? TabCode { get; set; }
        [MaxLength(5)]
        public string? TegaraCode { get; set; }
        [MaxLength(14), MinLength(14)]
        [Required]
        public string NationalId { get; set; } = string.Empty;
        [MaxLength(16)]
        public string? PhoneNumber { get; set; }
        [MaxLength(16)]
        [EmailAddress]
        public string? EmailAddress { get; set; }
        [MaxLength(50)]
        public string Collage { get; set; } = string.Empty;

        [MaxLength(20)]
        [Required]
        public QanonEnum Qanon { get; set; }
        public EmployeePositionEnum Position { get; set; }
        public virtual ICollection<EmployeeDepartmentModel>? Department { get; set; }
        public virtual EmployeeBankAccountModel? BankAccount { get; set; }

        public virtual ICollection<EmployeeGradeModel>? Grade { get; set; }

        public virtual ICollection<EmployeePartTimeModel>? PartTime { get; set; }
    }

}