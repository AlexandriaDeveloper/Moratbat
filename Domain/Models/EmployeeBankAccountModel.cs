using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

[Table("EmployeeBankAccount")]
public class EmployeeBankAccountModel : BaseEntityModel
{
    [NotMapped]
    public override int Id { get => base.Id; set => base.Id = value; }

    [NotMapped]
    public override string Name { get => base.Name; set => base.Name = value; }

    public int EmployeeId { get; set; }

    public int? BankAId { get; set; }
    [MaxLength(40)]
    public string AccountANumber { get; set; }

    public int? BankBId { get; set; }

    [MaxLength(40)]
    public string AccountBNumber { get; set; }



    public EmployeeModel Employee { get; set; }
    public BankBranchModel? BankA { get; set; }
    public BankBranchModel? BankB { get; set; }

}
