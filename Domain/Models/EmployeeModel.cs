using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Constants;

namespace Domain
{
    [Table("Employee")]
    public class EmployeeModel : BaseEntityModel
    {
        [MaxLength(5)]
        public string? TabCode { get; set; }
        [MaxLength(5)]
        public string? TegaraCode { get; set; }
        [MaxLength(14), MinLength(14)]
        [Required]
        public string NationalId { get; set; }
        [MaxLength(16)]
        public string? PhoneNumber { get; set; }
        [MaxLength(16)]
        [EmailAddress]
        public string? EmailAddress { get; set; }
        [MaxLength(50)]
        public string Collage { get; set; }
        public PaymentMethodEnum PaymentMethodA { get; set; }
        public PaymentMethodEnum PaymentMethodB { get; set; }
        [MaxLength(20)]
        [Required]
        public QanonEnum Qanon { get; set; }
        public EmployeePositionEnum Position { get; set; }
        public virtual ICollection<EmployeeDepartmentModel>? Department { get; set; }
        public virtual ICollection<EmployeeBankAccountModel>? BankAccount { get; set; }
        public virtual ICollection<EmployeeGradeModel>? Grade { get; set; }
    }
}