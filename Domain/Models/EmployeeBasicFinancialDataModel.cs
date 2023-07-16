
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Constants;

namespace Domain.Models
{
    [Table("EmployeeBasicFinancialData")]
    public class EmployeeBasicFinancialDataModel : BaseEntityModel
    {

        override public int Id { get; set; }
        [NotMapped]
        override public string Name { get; set; }
        public int EmployeeId { get; set; }

        public int AccountTreeDetailsId { get; set; }
        public int AccountTreeDetailsAccountTreeId { get; set; }
        public FinancialSourceEnum? FinancialSource { get; set; }
        public DateTime StartDate { get; set; }
        public Decimal Amount { get; set; }
        public bool Repeat { get; set; }

        public EmployeeModel Employee { get; set; }

        public AccountTreeDetailsModel AccountTreeDetails { get; set; }
    }


}
