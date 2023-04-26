using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.IdentityModels;
using Domain.Interfaces.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

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
            UUID = httpContextAccessor.HttpContext.User.FindFirstValue("UUID");
        }
        public void Insert(TEntity entity)
        {
            entity.CteaedAt = DateTime.UtcNow.ToLocalTime();
            entity.CreatedBy = UUID;
            this._context.Set<TEntity>().Add(entity);
        }

        public IQueryable<TEntity> GetQueryable()
        {
            return _context.Set<TEntity>();
        }

        private AppUser GetCurrentUser()
        {

            throw new NotImplementedException();
        }


    }
}