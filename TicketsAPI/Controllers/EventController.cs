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
    [Route("api/event")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService service;
        private readonly IMapper mapper;
        public EventController(IEventService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;

        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyCollection<Event>>> GetEvents(CancellationToken cancelationToken)
        {
            var _event = await service.GetAll(cancelationToken);
            var result = _event.ToList().Select(e => mapper.Map<EventViewModel>(e));
            return Ok(result);
        }
        [HttpGet("{userId}")]
        public async Task<ActionResult<IReadOnlyCollection<Event>>> GetUserEvents([FromRoute] int userId, CancellationToken cancelationToken)
        {
            var _event = await service.GetUserEvents(userId, cancelationToken);
            var result = _event.ToList().Select(e => mapper.Map<EventViewModel>(e));
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult> CreateEvent([FromBody] Event _event, CancellationToken cancelationToken)
        {
            await service.AddEvent(_event, cancelationToken);
            return Ok();
        }
        [HttpDelete("{eventId}")]
        public async Task<ActionResult>Delete([FromRoute] int eventId, CancellationToken cancelationToken)
        {
            var result = await service.DeleteEvent(eventId, cancelationToken);
            return Ok(result);
        }

    }
}
