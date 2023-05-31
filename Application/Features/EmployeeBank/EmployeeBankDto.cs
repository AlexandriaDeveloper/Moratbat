namespace Application.Features.EmployeeBank
{
    public class EmployeeBankDto {
        public int BankId { get; set; }
        public string? BankName { get; set; }
        public string? BranchName { get; set; }
        public string? AccountNumber { get; set; }

        public DateOnly? StartFrom { get; set; }
        public DateOnly? EndAt { get; set; }
    }
}