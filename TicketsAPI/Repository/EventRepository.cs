using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TicketsAPI.Entities;
using TicketsAPI.IRepository;

namespace TicketsAPI.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly AppDbContext dbContext;
        public EventRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<Event>> GetAll(CancellationToken cancelationToken)
        {
            var result =  await dbContext
                .Events
                .Include(t => t.Tickets)
                .ToListAsync(cancelationToken);
            return result;
                
        }
        public async Task<Event> GetById(int id, CancellationToken cancelationToken)
        {
            return await dbContext
                .Events
                .Include(t => t.Tickets)
                .FirstOrDefaultAsync(e => e.Id == id);
        }
        public async Task<IEnumerable<Event>> GetUserEvents(int userId, CancellationToken cancelationToken)
        {
            var result = await dbContext
                .Events
                .Include(t => t.Tickets)
                .ToListAsync();
            return result.FindAll(r => r.OwnerId == userId);
        }
        public async Task AddEvent(Event _event, CancellationToken cancelationToken)
        {
            await dbContext
                .Events
                .AddAsync(_event, cancelationToken);                        
            await dbContext.SaveChangesAsync(cancelationToken);
        }
        public async Task<bool> PayForEvent(int userId, double amount)
        {
            var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user != null && user.Wallet - amount >= 0)
            {
                user.Wallet -= amount;
                dbContext.Update(user);
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }
        public async Task<bool> DeleteEvent(int id, CancellationToken cancelationToken)
        {
            var _event = await dbContext
                .Events
                .Include(t => t.Tickets)
                .FirstOrDefaultAsync(e => e.Id == id);
            if (_event == null)
                return false;

            dbContext.Events.Remove(_event);
            await dbContext.SaveChangesAsync(cancelationToken);
                return true;
        }

    }
}
