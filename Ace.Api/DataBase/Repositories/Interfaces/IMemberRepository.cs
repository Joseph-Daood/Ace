
using Ace.Shared.Repositories;

namespace Ace.Api.DataBase.Repositories.Interfaces
{
    public interface IMemberRepository : IRepository<Member>
    {
        Member ActivateMember(int memberId, bool deactivate);

        Task<Member> GetByRegistrationNumber(string registrationNumber, bool checkLocal = false);

    }
}
