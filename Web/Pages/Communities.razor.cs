using Ace.Model;
using Microsoft.AspNetCore.Components;
using Web.Services;

namespace Web.Pages
{
    public partial class Communities
    {
        [Inject]
        public ICommunityDataService CommunityDataService { get; set; }

        public List<CommunityReadDto> CommunityList { get; set; }



        protected override async Task OnInitializedAsync()
        {
            CommunityList = (await CommunityDataService.GetcommuitysAsync()).ToList();
        }

    }
}
