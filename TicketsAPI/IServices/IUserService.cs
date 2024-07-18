using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TicketsAPI.Entities;

namespace TicketsAPI.IServices
{
    public interface IUserService
    {
        public Task<IEnumerable<User>> GetAll(CancellationToken cancelationToken);
        public Task<User> GetById(int id, CancellationToken cancelationToken);
        public Task AddUser(User user, CancellationToken cancelationToken);
        public Task<bool> DeleteUser(int id, CancellationToken cancelationToken);
        public Task AddMoneyToUser(int userId, double amount);
    }
}
