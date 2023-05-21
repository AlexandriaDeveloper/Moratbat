using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{

#nullable enable
    [Table("Branch")]
    public class BankBranchModel : BaseEntityModel
    {
        [Required]
        public override string Name { get => base.Name; set => base.Name = value; }
        [Required]
        public int BankId { get; set; }

        public BankModel? Bank { get; set; }
        public virtual ICollection<EmployeeBankAccountModel>? Employees { get; set; }

    }
}