using Ace.Api.Database;
using Ace.Api.DataBase.Repositories.Interfaces;
using ACE.Shared.Repositories;

namespace Ace.Api.DataBase.Repositories
{
    public class NotificationRepository : RepositoryBase<Notification, AceDbContext>, INotificationRepository
    {
        public NotificationRepository(AceDbContext context) : base(context)
        {
        }
    }
}
