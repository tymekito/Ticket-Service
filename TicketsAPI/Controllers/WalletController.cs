using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TicketsAPI.IServices;
using TicketsAPI.Models;

namespace TicketsAPI.Controllers
{
    [Route("api/wallet")]
    [ApiController]
    public class WalletController : ControllerBase
    {
        private readonly IUserService service;
        public WalletController(IUserService service)
        {
            this.service = service;
        }
        [HttpPost]
        public async Task<ActionResult> AddMoneyToUserWallet([FromForm] Payment model)
        {
            await service.AddMoneyToUser(model.UserId, model.Amount);
            return Ok();
        }
    }
}
