using Ace.Api.Database;
using Ace.Api.DataBase.Repositories.Interfaces;
using Ace.Api.Entities;
using ACE.Shared.Repositories;

namespace Ace.Api.DataBase.Repositories
{
    public class MemberRepository : RepositoryBase<Member, AceDbContext>, IMemberRepository
    {
        public MemberRepository(AceDbContext context) : base(context)
        {
        }

        public Member ActivateMember(int memberId, bool deactivate)
        {
            throw new NotImplementedException();
        }

        public Task<Member> GetByRegistrationNumber(string registrationNumber, bool checkLocal = false)
        {
            throw new NotImplementedException();
        }
    }
}
