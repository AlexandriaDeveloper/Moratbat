
using Domain;
using Persistence.Constants.Param;

namespace Persistence.Specifications.Bank
{
    public class BankSpecificaions : Specification<BankModel>
    {

        public BankSpecificaions(BankParam param)
        {

            if (param.Id.HasValue)
            {
                AddCriteries(x => x.Id == param.Id);
            }

            if (!string.IsNullOrEmpty(param.Name))
            {
                AddCriteries(x => x.Name.Contains(param.Name));
            }
        }
    }
}