using Ace.Api.DataBase.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ace.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationRepository _notificationRepository;

        public NotificationController(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        [HttpGet]
        public IEnumerable<Notification> Get()
        {
            return _notificationRepository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<Notification> Get(int id)
        {
            return await _notificationRepository.GetByIdAsync(id);
        }

        [HttpPost]
        public async void Post([FromBody] Notification value)
        {
            await _notificationRepository.InsertAsync(value);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Notification value)
        {
            _notificationRepository.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
