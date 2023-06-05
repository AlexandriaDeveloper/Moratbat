
using Domain;
using Persistence.Constants.Param;

namespace Persistence.Specifications
{

    public class GetEmployeeBasicInfoSpecification : Specification<EmployeeModel>
    {

        public GetEmployeeBasicInfoSpecification() : base()
        {
            AddInclude(x => x.Grade);
        }
    }
    public class EmployeeSpecification : Specification<EmployeeModel>
    {
        public EmployeeSpecification(EmployeeParam EmployeeParam)
        {


            if (EmployeeParam.Id.HasValue)
            {

                AddCriteries(x => x.Id.Equals(EmployeeParam.Id));
            }
            if (!string.IsNullOrEmpty(EmployeeParam.Name))
            {
                AddCriteries(x => x.Name.Contains(EmployeeParam.Name));
            }
            if (!string.IsNullOrEmpty(EmployeeParam.TabCode))
            {
                AddCriteries(x => x.TabCode!.Equals(EmployeeParam.TabCode));
            }
            if (!string.IsNullOrEmpty(EmployeeParam.TegaraCode))
            {
                AddCriteries(x => x.TegaraCode!.Equals(EmployeeParam.TegaraCode));
            }
            if (!string.IsNullOrEmpty(EmployeeParam.NationalId))
            {
                AddCriteries(x => x.NationalId!.Equals(EmployeeParam.NationalId));
            }

            if (!string.IsNullOrEmpty(EmployeeParam.Active))
            {
                if (EmployeeParam.Direction == "asc")
                {
                    if (EmployeeParam.Active.Equals("Name", StringComparison.OrdinalIgnoreCase))
                    {
                        AddOrderBy(x => x.Name);
                    }
                    if (EmployeeParam.Active.Equals("NationalId", StringComparison.OrdinalIgnoreCase))
                    {
                        AddOrderBy(x => x.NationalId);
                    }
                    if (EmployeeParam.Active.Equals("TabCode", StringComparison.OrdinalIgnoreCase))
                    {
                        AddOrderBy(x => x.TabCode!);
                    }
                    if (EmployeeParam.Active.Equals("TegaraCode", StringComparison.OrdinalIgnoreCase))
                    {
                        AddOrderBy(x => x.TegaraCode!);
                    }

                }
                if (EmployeeParam.Direction == "desc")
                {
                    if (EmployeeParam.Active.Equals("Name", StringComparison.OrdinalIgnoreCase))
                    {
                        AddOrderByDescending(x => x.Name);
                    }
                    if (EmployeeParam.Active.Equals("NationalId", StringComparison.OrdinalIgnoreCase))
                    {
                        AddOrderByDescending(x => x.NationalId);
                    }
                    if (EmployeeParam.Active.Equals("TabCode", StringComparison.OrdinalIgnoreCase))
                    {
                        AddOrderByDescending(x => x.TabCode!);
                    }
                    if (EmployeeParam.Active.Equals("TegaraCode", StringComparison.OrdinalIgnoreCase))
                    {
                        AddOrderByDescending(x => x.TegaraCode!);
                    }
                }
            }


        }

    }
}
