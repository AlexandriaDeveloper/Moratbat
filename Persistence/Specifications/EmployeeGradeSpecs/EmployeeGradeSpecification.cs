using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Persistence.Constants.Param;

namespace Persistence.Specifications.EmployeeGradeSpecs
{
    public class EmployeeGradeSpecification : Specification<EmployeeGradeModel>
    {
        public EmployeeGradeSpecification(EmployeeGradeParam param)
        {
            if (param.EmployeeId.HasValue)
            {
                AddCriteries(x => x.EmployeeId == param.EmployeeId);
            }
            if (param.GradeId.HasValue)
            {
                AddCriteries(x => x.GradeId == param.GradeId);
            }

            if (param.StartFrom.HasValue)
            {
                AddCriteries(x => x.StartFrom <= param.StartFrom);
            }
            if (param.EndAt.HasValue)
            {
                AddCriteries(x => x.EndAt >= param.EndAt);
            }
        }
    }
}