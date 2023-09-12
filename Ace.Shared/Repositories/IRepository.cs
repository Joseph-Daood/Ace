using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Ace.Shared.Helpers;
using Ace.Shared.Mapping;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Ace.Shared.Repositories
{
    public interface IRepository
    {

    }
    public interface IRepository<TEntity> : IRepository
        where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        Task<List<TEntity>> GetAllAsync();
        ValueTask<PagedList<TEntity>> GetAllAsync(ResourceParameters.ResourceParameters resourceParameters, Dictionary<string, PropertyMappingValue> propertyMapping);
        TEntity? GetById(params object[] Id);
        ValueTask<TEntity?> GetByIdAsync(params object[] Id);
        EntityEntry<TEntity> Insert(TEntity obj);
        ValueTask<EntityEntry<TEntity>> InsertAsync(TEntity obj);
        void Update(TEntity obj);
        void Update(TEntity updatedObject, params object[] id);
        void Delete(params object[] Id);

        void DeleteRange(List<TEntity> removeItems);
        void DeleteAll();
        void Reload(TEntity entity);

        IEnumerable<TEntity> CheckLocal(Func<TEntity, bool> func);

        ValueTask<bool> ExistsAsync(Expression<Func<TEntity, bool>> condition);
    }
}
