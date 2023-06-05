using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Persistence.Constants.Param;

namespace Persistence.Specifications.GradeSpecs
{
    public class GradeSpecificaions : Specification<GradeModel>
    {
        public GradeSpecificaions(GradeParam param)
        {
            if (param.OnlyParent.HasValue)
            {
                if (param.OnlyParent.Value == true)
                    AddCriteries(x => x.ParentId.HasValue == false);
                if (param.OnlyParent.Value == false)
                    AddCriteries(x => x.ParentId.HasValue == true);
            }
            if (param.ParentId.HasValue)
            {
                AddCriteries(x => x.ParentId == param.ParentId);
            }

            if (!string.IsNullOrEmpty(param.Name))
            {
                AddCriteries(x => x.Name == param.Name);
            }
            if (param.Qanon.HasValue)
            {
                AddCriteries(x => x.Qanon == param.Qanon);
            }
        }

    }
}