using Ace.Api.Models;
using AutoMapper;

namespace Ace.Api.Profiles
{
    public class FamilyProfile: Profile
    {
        public FamilyProfile()
        {
            CreateMap<Family, FamilyReadDto>().ReverseMap();

            CreateMap<FamilyCreateDto, Family>();
        }
    }
}
