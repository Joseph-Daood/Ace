
using Ace.Models;
using Microsoft.AspNetCore.Components;

namespace Web.Components
{
    public partial class FamilyCard
    {
        [Parameter]
        public FamilyReadDto Family { get; set; }

        [Parameter]
        public EventCallback<FamilyReadDto>  FamilyQuickViewClicked{ get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected override void OnInitialized()
        {
            var hello = "";
        }

        public void NavigateToDetails(FamilyReadDto selectedFamily)
        {
            NavigationManager.NavigateTo($"/familydetail/{selectedFamily.FamilyId}");
        }
    }
}
