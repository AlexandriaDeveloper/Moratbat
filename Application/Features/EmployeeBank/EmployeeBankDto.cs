using System;

namespace Application.Features.EmployeeBank
{
    public class EmployeeBankDto
    {
        public int? BankAId { get; set; }
        public string? BankAName { get; set; }
        public int? BranchAId { get; set; }
        public string? BranchAName { get; set; }
        public string? AccountANumber { get; set; }
        public int? BankBId { get; set; }
        public string? BankBName { get; set; }
        public int? BranchBId { get; set; }
        public string? BranchBName { get; set; }
        public string? AccountBNumber { get; set; }

    }

    public class EmployeeBankAccountRequest
    {

        public int EmployeeId { get; set; }
        public int BranchAId { get; set; }
        public int BranchBId { get; set; }
        public string AccountANumber { get; set; }
        public string AccountBNumber { get; set; }

    }

    public class CloseEmployeeBankAccountRequest
    {
        public int EmployeeId { get; set; }
        public int BankId { get; set; }
        public DateTime? EndAt { get; set; }
    }
}