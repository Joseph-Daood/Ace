namespace Ace.Model
{
    public class NotificationReadDto
    {
        public int NotificationId { get; set; }

        public string Title { get; set; }

        public string Message { get; set; }

        public DateTime ExpiredAt { get; set; }

        public bool IsActive { get; set; } = true;

        //public NoteficationFrom? NoteficationFrom { get; set; }
    }
}
