using Ace.Api.Database;
using Ace.Shared;
using Microsoft.EntityFrameworkCore;

namespace Ace.Api.DataBase
{
    public class UnitOfWork: IUnitOfWork
    {
        public AceDbContext Db { get; set; }

        public UnitOfWork(AceDbContext context)
        {
            Db = context;
        }

        //private Build Build => Db.Build;

        public void Commit()
        {
            Db.SaveChanges();//(Username, Build);
        }

        public Task<int> CommitAsync()
        {
            return Db.SaveChangesAsync();//(Username, Build); return Db.SaveChangesAsync(Username, Build);
        }

        public async Task<int> CommitAsync(Guid dataFileId)
        {
            return await Db.SaveChangesAsync(); // return Db.SaveChangesAsync(dataFileId, Username, Build);
        }

        public void ResetContextState()
        {
            var changedEntries = Db.ChangeTracker.Entries()
                .Where(e => e.Entity != null)
                .ToList();

            foreach (var changedEntry in changedEntries)
            {
                switch (changedEntry.State)
                {
                    case EntityState.Unchanged:
                    case EntityState.Deleted:
                    case EntityState.Modified:
                        changedEntry.State = EntityState.Unchanged;
                        break;

                    case EntityState.Added:
                        // This uses a pubternal API in entity framework. May break when updating EF version.
                        var keyName = changedEntry.Metadata.FindPrimaryKey().Properties.Select(x => x.Name).Single();
                        var keyValue = changedEntry.GetType().GetProperty(keyName)?.GetValue(changedEntry);

                        if (keyValue == null && changedEntry.IsKeySet)
                        {
                            // Setting State here will cause and exception in EF Core code IdentityMap.Remove(TKey key, InternalEntityEntry entity)
                            // since key will be null. The parameter key is constructed by PrincipalKeyValueFactory.CreateFromRelationshipSnapshot(entry) and
                            // that method will return null. IdentityMap.Remove will call _identityMap.TryGetValue(key, out var existingEntry) with key as null.
                            // Since _identityMap is a dictionary that call will throw an ArgumentNullException.
                            try
                            {
                                changedEntry.State = EntityState.Detached;
                            }
                            catch (Exception e)
                            {
                                // This is an attempt to get rid of the broken entity in the change tracker. It might or might not work ...
                                try
                                {
                                    Db.ChangeTracker.Entries().ToList().Remove(changedEntry);
                                }
                                catch (Exception)
                                {
                                    // FUBAR, nothing more to do than to throw.
                                    throw new Exception(
                                        $"Unable to reset context state since the primary key property '{keyName}' for '{changedEntry.Metadata.ClrType.Name}' " +
                                        "is null and that will cause and exception in EF Core. Made an attempt to remove the entity manually but that also failed.",
                                        e);

                                }
                            }
                        }

                        changedEntry.State = EntityState.Detached;
                        break;

                    case EntityState.Detached:
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}
