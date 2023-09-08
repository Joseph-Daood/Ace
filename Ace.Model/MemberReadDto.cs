using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ace.Model
{
    public class MemberReadDto
    {
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
    }
}
