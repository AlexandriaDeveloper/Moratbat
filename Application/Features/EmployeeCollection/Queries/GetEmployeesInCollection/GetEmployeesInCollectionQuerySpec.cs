using Persistence.Constants.Param;
using Persistence.Specifications;

namespace Application.Features.Collection.Queries.GetEmployeesInCollection
{
    public class GetEmployeesInCollectionQuerySpec : Specification<EmployeeCollectionModel>
    {
        public GetEmployeesInCollectionQuerySpec(int id, EmployeeInCollectionParam param) : base(x => x.CollectionId == id)
        {
            AddInclude(x => x.Employee);

            if (!string.IsNullOrEmpty(param.Name))
            {
                AddCriteries(x => x.Employee.Name.Contains(param.Name));
            }

            if (!string.IsNullOrEmpty(param.TabCode))
            {
                AddCriteries(x => x.Employee.TabCode.Equals(param.TabCode));
            }
            if (!string.IsNullOrEmpty(param.TegaraCode))
            {
                AddCriteries(x => x.Employee.TegaraCode.Equals(param.TegaraCode));
            }
            if (!string.IsNullOrEmpty(param.NationalId))
            {
                AddCriteries(x => x.Employee.NationalId.Equals(param.NationalId));
            }

        }
    }
}