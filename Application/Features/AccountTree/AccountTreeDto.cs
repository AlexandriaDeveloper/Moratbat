using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Constants;

namespace Application.Features.BudgetItems
{
    public class AccountTreeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? AccountParentId { get; set; }

    }

    public class AccountTreeDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AccountTreeId { get; set; }
        public AccountTreeModel AccountTree { get; set; }
    }

}