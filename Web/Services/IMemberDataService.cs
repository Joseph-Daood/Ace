using Ace.Model;

namespace Web.Services
{
    public interface IMemberDataService
    {
        Task<IEnumerable<MemberReadDto>> GetMembersAsync();

        Task<MemberReadDto> GetMemberAsync(int memberId);

        Task<MemberReadDto> AddMemberAsync(MemberReadDto member);

        Task RemoveMemberAsync(int memberId);
    }
}
