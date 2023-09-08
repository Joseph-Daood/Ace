using Ace.Models;
using System.Text;
using System.Text.Json;

namespace Web.Services
{
    public class FamilyDataService : DataServiceBase, IFamilyDataService
    {
        public FamilyDataService(HttpClient? httpClient) : base(httpClient)
        {
        }

        public async Task<FamilyReadDto> AddFamilyAsync(FamilyCreateDto family)
        {
            var familyJson = new StringContent(JsonSerializer.Serialize(family), Encoding.UTF8, "application/json");
            var response = await HttpClient.PostAsync("/api/families", familyJson);
            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<FamilyReadDto>(await response.Content.ReadAsStreamAsync());
            }

            return null;
        }

        public async Task<IEnumerable<FamilyReadDto>> GetFamiliesAsync()
        {
            var families = await JsonSerializer.DeserializeAsync<IEnumerable<FamilyReadDto>>
               (await HttpClient.GetStreamAsync($"api/families"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            if (families == null)
            {
                families = new List<FamilyReadDto>();// To avoid null.
            }
            return families;
        }

        public async Task<FamilyReadDto> GetFamilyAsync(int familyId)
        {
            return await JsonSerializer.DeserializeAsync<FamilyReadDto>
              (await HttpClient.GetStreamAsync($"api/families/{familyId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public Task RemoveFamilyAsync(int familyId)
        {
            throw new NotImplementedException();
        }
    }
}
