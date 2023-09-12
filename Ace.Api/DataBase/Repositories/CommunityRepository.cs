using Ace.Api.Database;
using Ace.Api.DataBase.Repositories.Interfaces;
using Ace.Api.Entities;
using ACE.Shared.Repositories;

namespace Ace.Api.DataBase.Repositories
{
    public class CommunityRepository : RepositoryBase<Community, AceDbContext>, ICommunityRepository
    {
        public CommunityRepository(AceDbContext context) : base(context)
        {
        }
    }
}
