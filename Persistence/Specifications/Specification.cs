using System.Linq.Expressions;
using Domain;
using Domain.Interfaces;

namespace Persistence.Specifications
{
#nullable disable
    public class Specification<TEntity> : ISpecification<TEntity>
    {

        public Expression<Func<TEntity, bool>> Criteria { get; }
        public List<Expression<Func<TEntity, bool>>> Criteries { get; } = new List<Expression<Func<TEntity, bool>>>();
        public List<Expression<Func<TEntity, object>>> Includes { get; } = new List<Expression<Func<TEntity, object>>>();
        public Expression<Func<TEntity, object>> OrderBy { get; private set; }

        public Expression<Func<TEntity, object>> OrderByDescending { get; private set; }
        public int Take { get; private set; }
        public int Skip { get; private set; }
        public int PageIndex { get; private set; }
        public int PageSize { get; private set; }

        public bool IsPagingEnabled { get; private set; }
        public Specification()
        {

        }
        public Specification(Expression<Func<TEntity, bool>> criteria)
        {
            if (criteria != null)
                Criteria = criteria;
        }


        protected void AddCriteries(Expression<Func<TEntity, bool>> criteria)
        {
            this.Criteries.Add(criteria);
        }
        protected void AddInclude(Expression<Func<TEntity, object>> include)
        {
            this.Includes.Add(include);
        }

        protected void AddOrderBy(Expression<Func<TEntity, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }
        protected void AddOrderByDescending(Expression<Func<TEntity, object>> orderByDescExpression)
        {
            OrderByDescending = orderByDescExpression;
        }

        protected void ApplyPaging(int skip, int take, int pageIndex, int pageSize)
        {
            Skip = skip;
            Take = take;
            IsPagingEnabled = true;
        }

    }
}