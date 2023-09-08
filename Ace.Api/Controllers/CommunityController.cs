using Ace.Api.DataBase.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ace.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommunityController : ControllerBase
    {
        private readonly ICommunityRepository _communityRepository;

        public CommunityController(ICommunityRepository communityRepository)
        {
            _communityRepository = communityRepository;
        }

        [HttpGet]
        public IEnumerable<Community> Get()
        {
            return _communityRepository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<Community> Get(int id)
        {
            return await _communityRepository.GetByIdAsync(id);
        }

        [HttpPost]
        public async void Post([FromBody] Community value)
        {
            await _communityRepository.InsertAsync(value);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Community value)
        {
            _communityRepository.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
