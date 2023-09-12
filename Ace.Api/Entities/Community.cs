
using Ace.Shared;

namespace Ace.Api.Entities
{
    public class Community : ObjectBase
    {
        public int CommunityId { get; set; }

        public string Name { get; set; }

        public string MainEmail { get; set; }

        public virtual List<Member> Members { get; set; }
    }
}
