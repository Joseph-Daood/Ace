using Ace.Shared.Helpers;
using Ace.Shared.Repositories;
using Ace.Shared.ResourceParameters;
using Isg.Shared.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace ACE.Shared.Repositories
{
    public abstract class RepositoryBase<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class
        where TContext : DbContext
    {
        private TContext db;
        private DbSet<TEntity> dbSet;

        public RepositoryBase(TContext context)
        {
            db = context;
            dbSet = db.Set<TEntity>();
        }

        protected DbSet<TEntity> DbSet => dbSet;

        public IEnumerable<TEntity> GetAll()
        {
            return Enumerable.ToList(dbSet);
        }

        public virtual Task<List<TEntity>> GetAllAsync()
        {
            return dbSet.ToListAsync();
        }

        public virtual TEntity? GetById(params object[] Id)
        {
            return dbSet.Find(Id);
        }

        public virtual ValueTask<TEntity?> GetByIdAsync(params object[] Id)
        {
            return dbSet.FindAsync(Id);
        }

        public EntityEntry<TEntity> Insert(TEntity obj)
        {
            return dbSet.Add(obj);
        }

        public ValueTask<EntityEntry<TEntity>> InsertAsync(TEntity obj)
        {
            obj.Validate();
            return dbSet.AddAsync(obj);
        }

        public async ValueTask<PagedList<TEntity>> GetAllAsync(ResourceParameters resourceParameters)
        {
            var collection = dbSet as IQueryable<TEntity>;

            //TODO for filter later
            //TODO for search later

            //return await collection.Skip(resourceParameters.PageSize * (resourceParameters.PageNumber - 1)).Take(resourceParameters.PageSize).ToListAsync();
            return await PagedList<TEntity>.CreateAsync(collection,
            resourceParameters.PageNumber,
            resourceParameters.PageSize);
        }

        public void Update(TEntity obj)
        {
            db.Entry(obj).State = EntityState.Modified;
        }

        public void Update(TEntity updatedObject, params object[] id)
        {
            var currentEntity = db.Set<TEntity>().Find(id);
            db.Entry(currentEntity).CurrentValues.SetValues(updatedObject);
            db.Entry(currentEntity).State = EntityState.Modified;
        }

        public void Delete(params object[] Id)
        {
            TEntity getObjById = dbSet.Find(Id);
            dbSet.Remove(getObjById);
        }

        public void DeleteRange(List<TEntity> removeItems)
        {
            dbSet.RemoveRange(removeItems);
        }

        public void DeleteAll()
        {
            dbSet.RemoveRange(dbSet);
        }

        public void Reload(TEntity entity)
        {
            db.Entry(entity).Reload();
        }

        public IEnumerable<TEntity> CheckLocal(Func<TEntity, bool> func)
        {
            return DbSet.Local.Where(func);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.db != null)
                {
                    this.db.Dispose();
                    this.db = null;
                }
            }
        }

        public async ValueTask<bool> ExistsAsync(Expression<Func<TEntity, bool>> condition)
        {
            return await dbSet
            .AsNoTracking()
            .AnyAsync(condition);
        }
    }
}

