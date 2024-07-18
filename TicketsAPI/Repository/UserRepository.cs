using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TicketsAPI.Entities;
using TicketsAPI.IRepository;

namespace TicketsAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext dbContext;
        public UserRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<User>> GetAll(CancellationToken cancelationToken)
        {
            var tmp = await dbContext
                .Users
                .Include(t => t.Tickets)
                .ToListAsync(cancelationToken);
            return tmp;

        }
        public async Task<User> GetById(int id)
        {
            return await dbContext
                .Users
                .Include(t => t.Tickets)
                .FirstOrDefaultAsync(e => e.Id == id);
        }
        public async Task<User> GetByLogin(string login)
        {
            return await dbContext
                .Users
                .Include(t => t.Tickets)
                .FirstOrDefaultAsync(e => e.Login == login);
        }
        public async Task AddMoneyToUser(int userId, double amount)
        {
            var user = await dbContext
                .Users
                .FirstOrDefaultAsync(u => u.Id == userId);
            user.Wallet += amount;
            dbContext.Update(user);
            dbContext.SaveChanges();
        }
        public async Task AddUser(User user, CancellationToken cancelationToken)
        {
            await dbContext
                .Users
                .AddAsync(user, cancelationToken);
            await dbContext.SaveChangesAsync(cancelationToken);
        }
        public async Task<bool> DeleteUser(int id, CancellationToken cancelationToken)
        {
            var user = await dbContext
                .Users
                .Include(t => t.Tickets)
                .FirstOrDefaultAsync(e => e.Id == id);
            if (user == null)
                return false;

            dbContext.Users.Remove(user);
            await dbContext.SaveChangesAsync(cancelationToken);
            return true;
        }
    }
}
