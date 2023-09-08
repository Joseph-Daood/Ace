using Ace.Model;
using Microsoft.AspNetCore.Components;
using Web.Services;

namespace Web.Pages
{
    public partial class Notifications
    {
        [Inject]
        public INotificationDataService NotificationDataService { get; set; }

        public List<NotificationReadDto> NotificationList { get; set; }

        protected override async Task OnInitializedAsync()
        {
            NotificationList = (await NotificationDataService.GetNotificationsAsync()).ToList();
        }
    }
}
