
using Ace.Shared.Repositories;
using ACE.Shared.Repositories;
using System.Threading.Tasks;

namespace Ace.Api.DataBase.Repositories.Interfaces
{
    public interface IFamilyRepository : IRepository<Family>
    {
        Task<Family> GetByIdentity(string identity, bool checkLocal = false);
    }
}
