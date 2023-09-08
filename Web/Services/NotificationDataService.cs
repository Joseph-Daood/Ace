using Ace.Model;
using System.Text.Json;
using Web.Pages;

namespace Web.Services
{
    public class NotificationDataService : DataServiceBase,  INotificationDataService
    {
        public NotificationDataService(HttpClient? httpClient) : base(httpClient)
        {
        }

        public Task<NotificationReadDto> AddNotificationAsync(NotificationReadDto notificationId)
        {
            throw new NotImplementedException();
        }

        public async Task<NotificationReadDto> GetNotificationAsync(int notificationId)
        {
            return await JsonSerializer.DeserializeAsync<NotificationReadDto>
                (await HttpClient.GetStreamAsync($"api/notification/{notificationId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<IEnumerable<NotificationReadDto>> GetNotificationsAsync()
        {
            var notifications = await JsonSerializer.DeserializeAsync<IEnumerable<NotificationReadDto>>
            (await HttpClient.GetStreamAsync($"api/notification"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            if (notifications == null)
            {
                notifications = new List<NotificationReadDto>();// To avoid null.
            }
            return notifications;
        }

        public Task RemoveNotificationAsync(int notificationId)
        {
            throw new NotImplementedException();
        }
    }
}
