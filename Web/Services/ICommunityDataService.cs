
using Ace.Model;

namespace Web.Services
{
    public interface ICommunityDataService
    {
        Task<IEnumerable<CommunityReadDto>> GetcommuitysAsync();
    }
}
