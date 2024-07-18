using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TicketsAPI.Entities;

namespace TicketsAPI.IRepository
{
    public interface ITicketRepository
    {
        public Task<IEnumerable<Ticket>> GetAll(CancellationToken cancelationToken);
        public Task<List<Ticket>> GetTicketListByUserId(int id, CancellationToken cancelationToken);
        public Task AddTicketWithUserToEvent(Ticket ticket, CancellationToken cancelationToken);
        public Task<bool> DeleteTicket(int id, CancellationToken cancelationToken);

    }
}
