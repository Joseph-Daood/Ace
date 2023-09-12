using Ace.Api.Database;
using Ace.Api.DataBase.Repositories.Interfaces;
using Ace.Api.Entities;
using ACE.Shared.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

namespace Ace.Api.DataBase.Repositories
{
    public class FamilyRepository : RepositoryBase<Family, AceDbContext>, IFamilyRepository
    {
        public FamilyRepository(AceDbContext context) : base(context)
        {
        }

        public async Task<Family> GetByIdentity(string identity, bool checkLocal = false)
        {
            return await DbSet.SingleAsync(x => identity.Equals(x.Identity));
        }
    }
}
