using Ace.Model;
using System.Text;
using System.Text.Json;

namespace Web.Services
{
    public class MemberDataService : DataServiceBase, IMemberDataService
    {

        public MemberDataService(HttpClient? httpClient): base(httpClient)
        {
        }

        public async Task<IEnumerable<MemberReadDto>> GetMembersAsync()
        {
            var members = await JsonSerializer.DeserializeAsync<IEnumerable<MemberReadDto>>
               (await HttpClient.GetStreamAsync($"api/member"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            if(members == null)
            {
                members = new List<MemberReadDto>();// To avoid null.
            }
            return members;
        }

        public async Task<MemberReadDto> GetMemberAsync(int memberId)
        {
            return await JsonSerializer.DeserializeAsync<MemberReadDto>
               (await HttpClient.GetStreamAsync($"api/member/{memberId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<MemberReadDto> AddMemberAsync(MemberReadDto member)
        {
            var memberJson = new StringContent(JsonSerializer.Serialize(member), Encoding.UTF8, "application/json");
            var response = await HttpClient.PostAsync("api/employee", memberJson);
            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<MemberReadDto>(await response.Content.ReadAsStreamAsync());
            }

            return null;
        }

        public async Task RemoveMemberAsync(int memberId)
        {
            await HttpClient.DeleteAsync($"api/member/{memberId}");
        }
    }
}
