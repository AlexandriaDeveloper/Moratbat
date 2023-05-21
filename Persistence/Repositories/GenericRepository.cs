
using Domain;
using Domain.IdentityModels;
using Domain.Interfaces.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Domain.Interfaces;
using Persistence.Specifications;

namespace Persistence.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntityModel
    {
        protected readonly AppDataContext _context;
        protected readonly UserManager<AppUser> _userManager;
        protected readonly IHttpContextAccessor _accessor;
        protected readonly string UUID;
        protected GenericRepository(AppDataContext context, UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            this._context = context;
            this._userManager = userManager;
            _accessor = httpContextAccessor;
            UUID = httpContextAccessor.HttpContext.User.FindFirstValue("UUID") ?? string.Empty;
        }
        public void Insert(TEntity entity)
        {
            entity.CteaedAt = DateTime.UtcNow.ToLocalTime();
            entity.CreatedBy = UUID;
            this._context.Set<TEntity>().Add(entity);
        }
        public void Update(TEntity entity)
        {
            entity.UpdatedAt = DateTime.UtcNow.ToLocalTime();
            entity.UpdatedBy = UUID;
            this._context.Set<TEntity>().Update(entity);
        }
        public async Task<List<TEntity>> GetAllAsync()
        {
            return await this._context.Set<TEntity>().ToListAsync();
        }
        public async Task<List<TEntity>> GetAllWithSpecAsync(ISpecification<TEntity> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }
        public async Task<PaginatedResult<TEntity>> GetPagedBySpecificationAsync(ISpecification<TEntity> spec, int PageIndex, int PageSize)
        {
            if (PageIndex < 1)
            {
                PageIndex = 1;
            }
            var query = ApplySpecification(spec);
            var totalCount = await query.CountAsync();
            var totalPages = (int)Math.Ceiling(totalCount / (double)PageSize);
            var paginatedData = await query.Skip((PageIndex - 1) * PageSize).Take(PageSize).ToListAsync();
            return new PaginatedResult<TEntity>(PageIndex, PageSize, totalCount, paginatedData);

        }
        public async Task<TEntity?> GetByIdAsync(int id)
        {
            return await this._context.Set<TEntity>().FindAsync(id);
        }
        public async Task<TEntity?> GetByWithSpecAsync(ISpecification<TEntity> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }
        public IQueryable<TEntity> GetQueryable()
        {
            return _context.Set<TEntity>();
        }


        private IQueryable<TEntity> ApplySpecification(ISpecification<TEntity> spec)
        {
            return SpecificationEvaluator<TEntity>.GetQuery(_context.Set<TEntity>().AsQueryable(), spec);
        }


    }
}