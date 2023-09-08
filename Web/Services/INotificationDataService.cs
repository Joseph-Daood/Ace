using Ace.Model;

namespace Web.Services
{
    public interface INotificationDataService
    {
        Task<IEnumerable<NotificationReadDto>> GetNotificationsAsync();

        Task<NotificationReadDto> GetNotificationAsync(int notificationId);

        Task<NotificationReadDto> AddNotificationAsync(NotificationReadDto notificationId);

        Task RemoveNotificationAsync(int notificationId);
    }
}
