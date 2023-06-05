namespace Persistence.Constants.Param
{
    public class BankBranchParam : Param{

        public int? Id { get; set; }
        public string? Name { get; set; }
        public int? BankId { get; set; }
        public string? BankName { get; set; }
    }
}