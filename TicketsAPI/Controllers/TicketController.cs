using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TicketsAPI.Entities;
using TicketsAPI.IServices;

namespace TicketsAPI.Controllers
{
    [Route("api/ticket")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService service;
        private readonly IMapper mapper;
        public TicketController(ITicketService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyCollection<Ticket>>> GetTickets(CancellationToken cancelationToken)
        {
            var ticket = await service.GetAll(cancelationToken);
            var result = ticket.ToList().Select(e => mapper.Map<TicketViewModel>(e));
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<IReadOnlyCollection<Ticket>>> GetTicketById([FromRoute] int id, CancellationToken cancelationToken)
        {
            var ticket = await service.GetById(id, cancelationToken);
            var result = mapper.Map<TicketViewModel>(ticket);
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult> CreateEvent([FromBody] Ticket ticket, CancellationToken cancelationToken)
        {
            await service.AddTicketWithUserToEvent(ticket, cancelationToken);
            return Ok();
        }
        [HttpDelete("{ticketId}")]
        public async Task<ActionResult> Delete([FromRoute] int ticketId, CancellationToken cancelationToken)
        {
            var result = await service.DeleteTicket(ticketId, cancelationToken);
            return Ok(result);
        }
    }
}
