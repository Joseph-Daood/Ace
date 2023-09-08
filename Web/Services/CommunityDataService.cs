using Ace.Model;
using System.Text.Json;

namespace Web.Services
{
    public class CommunityDataService : DataServiceBase, ICommunityDataService
    {
        public CommunityDataService(HttpClient? httpClient) : base(httpClient)
        {
        }

        public async Task<IEnumerable<CommunityReadDto>> GetcommuitysAsync()
        {
            var commuities = await JsonSerializer.DeserializeAsync<IEnumerable<CommunityReadDto>>
               (await HttpClient.GetStreamAsync($"api/community"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            if (commuities == null)
            {
                commuities = new List<CommunityReadDto>();// To avoid null.
            }
            return commuities;
        }
    }
}
