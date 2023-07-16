using Domain;
using Persistence.Constants.Param;

namespace Persistence.Specifications.Bank
{
    public class BankBranchSpecs : Specification<BankBranchModel>
    {

        public BankBranchSpecs(BankBranchParam param)
        {
            AddInclude(x => x.Bank);
            if (param.Id.HasValue)
            {
                AddCriteries(x => x.Id == param.Id);
            }

            if (param.BankId.HasValue)
            {
                AddCriteries(x => x.BankId == param.BankId);
            }

            if (!string.IsNullOrEmpty(param.Name))
            {
                AddCriteries(x => x.Name.Contains(param.Name));
            }
            if (!string.IsNullOrEmpty(param.BankName))
            {
                AddCriteries(x => x.Bank.Name.Contains(param.BankName));
            }
        }
    }
}