using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    #nullable enable
    [Table("Bank")]
    public class BankModel : BaseEntityModel
    {
        [Required]
        public override string Name { get => base.Name; set => base.Name = value; }

        public List<BankBranchModel>? Branches { get; set; }
    }
}