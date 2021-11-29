using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TicketsAPI.Entities;
using TicketsAPI.IRepository;
using TicketsAPI.IServices;

namespace TicketsAPI.Services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository ticketRepository;
        public TicketService(ITicketRepository ticketRepository)
        {
            this.ticketRepository = ticketRepository;
        }
        public async Task<IEnumerable<Ticket>> GetAll(CancellationToken cancelationToken)
        {
            var tickets = await ticketRepository.GetAll(cancelationToken);
            return tickets;
        }
        public async Task<Ticket> GetById(int id, CancellationToken cancelationToken)
        {
            var ticketById = await ticketRepository.GetById(id, cancelationToken);
            return ticketById;
        }
        public async Task AddTicketWithUserToEvent(Ticket ticket, CancellationToken cancelationToken)
        {
            await ticketRepository.AddTicketWithUserToEvent(ticket, cancelationToken);
        }
        public async Task<bool> DeleteTicket(int id, CancellationToken cancelationToken)
        {
            return await ticketRepository.DeleteTicket(id, cancelationToken);
        }

    }
}
