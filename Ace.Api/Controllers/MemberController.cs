using Ace.Api.DataBase.Repositories.Interfaces;
using Ace.Api.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ace.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMemberRepository _memberRepository;

        public MemberController(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        // GET: api/<EmemberController>
        [HttpGet]
        public IEnumerable<Member> Get()
        {
            return _memberRepository.GetAll();
        }

        // GET api/<EmemberController>/5
        [HttpGet("{memberId}")]
        public Member Get(int memberId)
        {
            return _memberRepository.GetById(memberId);
        }

        // POST api/<EmemberController>
        [HttpPost]
        public async Task<Member> Post([FromBody] Member value)
        {
            await _memberRepository.InsertAsync(value);
            return value;
        }

        // PUT api/<EmemberController>/5
        [HttpPut("{id}")]
        public async Task PutAsync(int id, [FromBody] Member value)
        {
            await _memberRepository.InsertAsync(value);
        }

        // DELETE api/<EmemberController>/5
        [HttpDelete("{memberId}")]
        public void Delete(int memberId)
        {
            _memberRepository.Delete(memberId);
        }
    }
}
