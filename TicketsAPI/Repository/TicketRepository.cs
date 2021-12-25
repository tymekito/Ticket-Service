using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TicketsAPI.Entities;
using TicketsAPI.IRepository;

namespace TicketsAPI.Repository
{
    public class TicketRepository : ITicketRepository
    {
        private readonly AppDbContext dbContext;
        public TicketRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<Ticket>> GetAll(CancellationToken cancelationToken)
        {
            return await dbContext
                .Tickets
                .ToListAsync(cancelationToken);
        }
        public async Task<List<Ticket>> GetTicketListByUserId(int userId, CancellationToken cancelationToken)
        {
            return await dbContext
                .Tickets
                .Where( t => t.UserId == userId)
                .ToListAsync();
        }
        public async Task AddTicketWithUserToEvent(Ticket ticket, CancellationToken cancelationToken)
        {
            await dbContext
                .Tickets
                .AddAsync(ticket, cancelationToken);

            await dbContext.SaveChangesAsync(cancelationToken);
        }
        public async Task<bool> DeleteTicket(int id, CancellationToken cancelationToken)
        {
            var ticket = await dbContext
                .Tickets
                .FirstOrDefaultAsync(e => e.Id == id);
            if (ticket == null)
                return false;

            dbContext.Tickets.Remove(ticket);
            await dbContext.SaveChangesAsync(cancelationToken);
            return true;
        }
    }
}
