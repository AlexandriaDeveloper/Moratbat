using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    [Table("EmployeeBankAccount")]
    public class EmployeeBankAccountModel : BaseEntityModel
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
        public int BankId { get; set; }
        [MaxLength(40)]
        public string EmployeeAccountNumber { get; set; }

        public DateTime StartFrom { get; set; }
        public DateTime? EndAt { get; set; }
        public EmployeeModel Employee { get; set; }
        public BankBranchModel Bank { get; set; }

    }
}