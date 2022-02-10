using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BookApi.Entities;
using BookApi.IServices;
namespace BookApi.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService service;
        private readonly IMapper mapper;
        public UserController(IUserService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;

        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyCollection<User>>> GetUsers(CancellationToken cancelationToken)
        {
            var users = await service.GetAll(cancelationToken);
            var result = users.ToList().Select(e => mapper.Map<UserViewModel>(e));
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<IReadOnlyCollection<User>>> GetUserById([FromRoute] int id, CancellationToken cancelationToken)
        {
            var user = await service.GetById(id, cancelationToken);
            var result = mapper.Map<UserViewModel>(user);
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult> CreateUser([FromBody] User user, CancellationToken cancelationToken)
        {
            await service.AddUser(user, cancelationToken);
            return Ok();
        }
        [HttpDelete("{userId}")]
        public async Task<ActionResult> Delete([FromRoute] int userId, CancellationToken cancelationToken)
        {
            var result = await service.DeleteUser(userId, cancelationToken);
            return Ok(result);
        }
    }
}
