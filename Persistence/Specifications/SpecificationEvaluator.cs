using Domain;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Specifications
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntityModel
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> spec)
        {

            var query = inputQuery;
            //query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));
            // if (!trackingChange)
            // {
            //     query = query.AsNoTracking();
            // }
            if (spec.Criteria != null)
            {
                query = query.Where(spec.Criteria);
            }

            if (spec.Criteries.Count > 0)
            {
                foreach (var criteria in spec.Criteries)
                {
                    query = query.Where(criteria);
                }
            }


            if (spec.OrderBy != null)
            {
                query = query.OrderBy(spec.OrderBy);

            }
            if (spec.OrderByDescending != null)
            {
                query = query.OrderByDescending(spec.OrderByDescending);
            }
            // if (spec.IsPagination)

            //     query = query.Skip(spec.PageIndex * spec.PageSize).Take(spec.PageSize);

            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));

            return query;
        }

    }
}