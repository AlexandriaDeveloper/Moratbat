using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Features.BankBranche
{
    public class BankBranchDto
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public int? BankId { get; set; }
    }
}