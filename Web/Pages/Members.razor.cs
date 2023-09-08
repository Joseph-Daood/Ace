using Ace.Model;
using Microsoft.AspNetCore.Components;
using Web.Services;

namespace Web.Pages
{
    public partial class Members
    {
        [Inject]
        public IMemberDataService memberDataService { get; set; }

        public List<MemberReadDto> MemberList { get; set; } = new List<MemberReadDto>();

        protected override async Task OnInitializedAsync()
        {
            MemberList = (await memberDataService.GetMembersAsync()).ToList();
        }
    }
}
