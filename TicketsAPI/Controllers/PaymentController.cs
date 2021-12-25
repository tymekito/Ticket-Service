using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TicketsAPI.IServices;
using TicketsAPI.Models;

namespace TicketsAPI.Controllers
{
    [Route("api/payment")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IUserService service;
        public PaymentController(IUserService service)
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
