using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repository
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntityModel
    {
        void Insert(TEntity entity);
        IQueryable<TEntity> GetQueryable();
    }
}