using Ace.Api.Database;

namespace Ace.Api.DataBase
{

    public interface IUnitOfWork 
    {
        AceDbContext Db { get; set; }

        void Commit();

        Task<int> CommitAsync();

        Task<int> CommitAsync(Guid dataFileId);

        void ResetContextState();
    }
}
