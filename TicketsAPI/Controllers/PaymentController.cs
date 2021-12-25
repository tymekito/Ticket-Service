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
        private readonly IEventService service;
        public PaymentController(IEventService service)
        {
            this.service = service;
        }

        [HttpPost]
        public async Task<ActionResult> PayForEvent([FromForm] Payment model)
        {
            var responce = await service.PayForEvent(model.UserId, model.Amount);
            return Ok(responce);
        }
    }
}
