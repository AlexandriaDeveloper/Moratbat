using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Persistence.Repositories;

namespace Domain.Interfaces.Repository
{
#nullable enable
    public interface IGenericRepository<TEntity> where TEntity : BaseEntityModel
    {

        Task<List<TEntity>> GetAllAsync();


        Task<List<TEntity>> GetAllWithSpecAsync(ISpecification<TEntity> spec);
        Task<TEntity?> GetByWithSpecAsync(ISpecification<TEntity> spec);

        Task<TEntity?> GetByIdAsync(int id);
        IQueryable<TEntity> GetQueryable();
        Task Insert(TEntity entity, CancellationToken cancellationToken);
        public void Update(TEntity entity);

        Task<PaginatedResult<TEntity>> GetPagedBySpecificationAsync(ISpecification<TEntity> spec, int PageIndex, int PageSize);
    }
}