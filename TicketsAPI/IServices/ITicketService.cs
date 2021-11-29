using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TicketsAPI.Entities;


namespace TicketsAPI.IServices
{
    public interface ITicketService
    {
        public Task<IEnumerable<Ticket>> GetAll(CancellationToken cancelationToken);
        public Task<Ticket> GetById(int id, CancellationToken cancelationToken);
        public Task AddTicketWithUserToEvent(Ticket ticket, CancellationToken cancelationToken);
        public Task<bool> DeleteTicket(int id, CancellationToken cancelationToken);

    }
}
