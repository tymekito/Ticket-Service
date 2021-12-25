using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TicketsAPI.Entities;

namespace TicketsAPI.IRepository
{
    public interface IEventRepository
    {
        public Task<IEnumerable<Event>> GetAll(CancellationToken cancelationToken);
        public Task<Event> GetById(int id, CancellationToken cancelationToken);
        public Task<IEnumerable<Event>> GetUserEvents(int userId, CancellationToken cancelationToken);
        public Task AddEvent(Event _event, CancellationToken cancelationToken);
        public Task<bool> PayForEvent(int userId, double amount);
        public Task<bool> DeleteEvent(int id, CancellationToken cancelationToken);

    }
}
