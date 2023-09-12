using Ace.Shared;

namespace Ace.Api.Entities
{
    public class Family: ObjectBase
    {
        public int FamilyId { get; set; }

        public string Identity { get; set; }

        public string Name { get; set; }

        public virtual List<Member> Members { get; set; } = new List<Member>();
    }
}
