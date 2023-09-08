using Ace.Models;
using Microsoft.AspNetCore.Components;
using Web.Services;

namespace Web.Pages
{
    public partial class FamilyEdit
    {

        public FamilyCreateDto Family { get; set; } = new FamilyCreateDto();

        [Parameter]
        public int? FamilyId { get; set; }

        [Inject]
        public IFamilyDataService? FamilyDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected bool Saved;

        protected override Task OnInitializedAsync()
        {
            return base.OnInitializedAsync();
        }

        protected async Task HandleValidSubmit()
        {
            await FamilyDataService.AddFamilyAsync(Family);
        }

        protected async Task HandleInvalidSubmit()
        {

        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/families");
        }
    }
}
