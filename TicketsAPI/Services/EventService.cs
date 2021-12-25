using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TicketsAPI.Entities;
using TicketsAPI.IRepository;
using TicketsAPI.IServices;

namespace TicketsAPI.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository eventRepository;
        public EventService(IEventRepository eventRepository)
        {
            this.eventRepository = eventRepository;
        }
        public async Task<IEnumerable<Event>> GetAll(CancellationToken cancelationToken)
        {
            var events = await eventRepository.GetAll(cancelationToken);
            return events;
        }
        public async Task<Event> GetById(int id, CancellationToken cancelationToken)
        {
            var eventById = await eventRepository.GetById(id, cancelationToken);
            return eventById;
        }
        public async Task<IEnumerable<Event>> GetUserEvents(int userId, CancellationToken cancelationToken)
        {
            var eventById = await eventRepository.GetUserEvents(userId, cancelationToken);
            return eventById;
        }
        public async Task AddEvent(Event _event, CancellationToken cancelationToken)
        {
            await eventRepository.AddEvent(_event, cancelationToken);
        }
        public async Task<bool> PayForEvent(int userId,  double amount)
        {
            var eventById = await eventRepository.PayForEvent(userId, amount );
            return eventById;
        }
        public async Task<bool> DeleteEvent(int id, CancellationToken cancelationToken)
        {
            return await eventRepository.DeleteEvent(id, cancelationToken);
        }

    }
}
