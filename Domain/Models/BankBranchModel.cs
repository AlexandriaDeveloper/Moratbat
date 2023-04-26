using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    [Table("Branch")]
    public class BankBranchModel : BaseEntityModel
    {
        [Required]
        public override string Name { get => base.Name; set => base.Name = value; }
        public int BankId { get; set; }
        public BankModel Bank { get; set; }
        public virtual ICollection<EmployeeBankAccountModel>? Employees { get; set; }

    }
}