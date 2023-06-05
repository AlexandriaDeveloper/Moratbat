using Application.Features.BankBranche;

namespace Application.Features.Bank.Queries.GetBanks
{
#nullable enable
    public class BankDto
    {
        public int? Id { get; set; }
        public string? Name { get; set; }

        public int? BranchesCount { get; set; }

        public List<BankBranchDto>? Branches { get; set; }


    }
}