using Microsoft.EntityFrameworkCore;

namespace Ace.Api.Database
{
    public abstract class DbContextBase : DbContext
    {
        protected DbContextBase(DbContextOptions<AceDbContext> options) : base(options) { }


        protected DbContextBase(DbContextOptions options) : base(options)
        {

        }

        //protected internal Task<int> SetAuditPropertiesAndSaveAsync()
        //{
        //    return SetAuditPropertiesAndSaveAsync(GetBuild());
        //}

        //protected internal Task<int> SetAuditPropertiesAndSaveAsync(string changedBy, Guid dataFileId = default)
        //{
        //    foreach (var entity in ChangeTracker.Entries<IAuditable>().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified))
        //    {
        //        if (entity.State == EntityState.Added)
        //        {
        //            entity.Property("CreatedBy").CurrentValue = changedBy;
        //            entity.Property("CreatedDate").CurrentValue = DateTime.UtcNow;
        //        }
        //        else if (entity.State == EntityState.Modified)
        //        {
        //            entity.Property("ModifiedBy").CurrentValue = changedBy;
        //            entity.Property("ModifiedDate").CurrentValue = DateTime.UtcNow;
        //        }
        //    }
        //    return SaveChangesAsync();
        //}
    }
}
