using Domain.Interfaces;
using Persistence.Constants.Param;
using Persistence.Specifications;

namespace Application.Features.Collection.Queries.GetCollictions
{
    public class CollectionListSpec : Specification<CollectionModel>
    {
        public CollectionListSpec(CollectionParam param)
        {
            AddInclude(x => x.EmployeeCollection);
            if (!string.IsNullOrEmpty(param.Name))
            {
                AddCriteries(x => x.Name.Contains(param.Name));
            }




        }
    }
}