using Ace.Shared;
using System.ComponentModel.DataAnnotations;

namespace Ace.Api.Entities
{
    public enum NoteficationFrom
    {
        Leader = 10,
        CommunityResponsible = 20,
        GlobalAgency = 30,
        LocalAgency = 40,
    }
    public class Notification : ObjectBase
    {
        [Key]
        public int NotificationId { get; set; }

        public string Title { get; set; }

        public string Message { get; set; }

        public DateTime ExpiredAt { get; set; }

        public bool IsActive { get; set; } = true;

        public NoteficationFrom? NoteficationFrom { get; set; }

        public List<Community> ToCommunities { get; set; } = new List<Community>(); // Is not defined ,that means is for all communites.

    }
}
