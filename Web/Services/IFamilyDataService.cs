using Ace.Models;

namespace Web.Services
{
    public interface IFamilyDataService
    {
        Task<IEnumerable<FamilyReadDto>> GetFamiliesAsync();

        Task<FamilyReadDto> GetFamilyAsync(int familyId);

        Task<FamilyReadDto> AddFamilyAsync(FamilyCreateDto family);

        Task RemoveFamilyAsync(int familyId);
    }
}
