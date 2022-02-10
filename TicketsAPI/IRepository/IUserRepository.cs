using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BookApi.Entities;

namespace BookApi.IRepository
{
    public interface IUserRepository
    {
        public Task<IEnumerable<User>> GetAll(CancellationToken cancelationToken);
        public Task<User> GetById(int id);
        public Task<User> GetByLogin(string login);
        public Task AddUser(User user, CancellationToken cancelationToken);
        public Task AddMoneyToUser(int userId, double amount);
        public Task<bool> DeleteUser(int id, CancellationToken cancelationToken);
    }
}
