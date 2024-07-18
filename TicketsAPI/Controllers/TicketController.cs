using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TicketsAPI.Entities;
using TicketsAPI.IServices;
using TicketsAPI.Models;

namespace TicketsAPI.Controllers
{
    [Route("api/ticket")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService service;
        private readonly IEventService eventService;
        private readonly IMapper mapper;
        public TicketController(ITicketService service, IEventService eventService, IMapper mapper)
        {
            this.service = service;
            this.eventService = eventService;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyCollection<Ticket>>> GetTickets(CancellationToken cancelationToken)
        {
            var ticket = await service.GetAll(cancelationToken);
            var result = ticket.ToList().Select(e => mapper.Map<TicketViewModel>(e));
            return Ok(result);
        }
        [HttpGet("{userId}")]
        public async Task<ActionResult<IReadOnlyCollection<Ticket>>> GetTicketsForUser([FromRoute] int userId, CancellationToken cancelationToken)
        {
            var tickets = await service.GetTicketListByUserId(userId, cancelationToken);
            var result = tickets.ToList().Select(e => mapper.Map<TicketViewModel>(e));
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> AddTicketToEvent(Ticket model, CancellationToken cancelationToken)
        {
            await service.AddTicketWithUserToEvent(model, cancelationToken);
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
