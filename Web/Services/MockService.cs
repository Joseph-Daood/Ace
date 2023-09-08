using Ace.Model;

namespace Web.Services
{
    public class MockService
    {
        public List<MemberReadDto> GetAllMembers()
        {
            return new List<MemberReadDto>
            {
                new MemberReadDto
                {
                    MemberId = 1,
                    FirstName = "FirstName_Test01",
                    LastName = "LastName_Test01",
                    BirthDate = new DateTime(1995,10,10),
                    FullAddress = "FullAddress_Test01",
                    Email = "email_Test01@.email.com",
                    PhoneNumber = "1234567890",
                },
                new MemberReadDto
                {
                    MemberId = 2,
                    FirstName = "FirstName_Test02",
                    LastName = "LastName_Test02",
                    BirthDate = new DateTime(1995,10,10),
                    FullAddress = "FullAddress_Test02",
                    Email = "email_Test02@.email.com",
                    PhoneNumber = "1234567890",
                },
                new MemberReadDto
                {
                    MemberId = 3,
                    FirstName = "FirstName_Test03",
                    LastName = "LastName_Test3",
                    BirthDate = new DateTime(1995,10,10),
                    FullAddress = "FullAddress_Test03",
                    Email = "email_Test01@.email.com",
                    PhoneNumber = "1234567890",
                },
            };
        }

        public static List<CommunityReadDto> GetAllCommunities()
        {
            return new List<CommunityReadDto>
            {
                new CommunityReadDto
                {
                    CommunityId = 1,
                    Name = "Linköping",
                    MainEmail = "Linkpoing.Community@mail.com"
                },
                new CommunityReadDto
                {
                    CommunityId = 2,
                    Name = "Jönköping",
                    MainEmail = "Jonkoping.Community@mail.com"
                },
            };
        }

        public static List<NotificationReadDto> GetAllNotifications()
        {
            return new List<NotificationReadDto>
            {
                new NotificationReadDto
                {
                   NotificationId = 1,
                   ExpiredAt = new DateTime(2023,12,12),
                   IsActive = true,
                   Title = "Title Test 01",
                   Message = "Verey long message for now for test 01",
                },
                 new NotificationReadDto
                {
                   NotificationId = 2,
                   ExpiredAt = new DateTime(2023,12,12),
                   IsActive = true,
                   Title = "Title Test 02",
                   Message = "Verey long message for now for test 02",
                },
                  new NotificationReadDto
                {
                   NotificationId = 3,
                   ExpiredAt = new DateTime(2023,12,12),
                   IsActive = true,
                   Title = "Title Test 03",
                   Message = "Verey long message for now for test 03",
                },
            };
        }
    }
}
