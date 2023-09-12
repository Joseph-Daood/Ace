using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Ace.Shared;

namespace Ace.Api.Entities
{
    public class Member: ObjectBase
    {
        [Key]
        public int MemberId { get; set; }

        public string Identity { get; set; }

        public string? FirstName { get; set; }

        public string MiddleName { get; set; }

        public string? LastName { get; set; }
        
        public string? FullName { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }

        public string? FullAddress { get; set; }

        public string? RegistrationNumber { get; set; }

        public bool IsMainFamilyPerson { get; set; }

        public string TelephoneNumber1 { get; set; }

        public string TelephoneNumber2 { get; set; }

        public string? CprNumber { get; set; }

        public bool IsActive { get; set; }

        public bool IsUnderAge { get; set; }

        public bool IsMale { get; set; }

        public string Contry { get; set; }

        public bool IsMarried { get; set; }

        public string Profession { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BirthDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? WeddingDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BaptismalDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ActiveDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? RegistrationDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DeathDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? MovingDatetoNewCommuity { get; set; }

        public virtual Family? Family { get; set; }

        [ForeignKey("Family")]
        public int? FamilyId { get; set; }

        public virtual Community? Community { get; set; }
        [ForeignKey("Community")]
        public int? communityId { get; set; }
    }
}
