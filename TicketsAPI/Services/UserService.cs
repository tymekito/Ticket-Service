using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BookApi.Entities;
using BookApi.IRepository;
using BookApi.IServices;

namespace BookApi.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public async Task<IEnumerable<User>> GetAll(CancellationToken cancelationToken)
        {
            var tickets = await userRepository.GetAll(cancelationToken);
            return tickets;
        }
        public async Task<User> GetById(int id, CancellationToken cancelationToken)
        {
            var ticketById = await userRepository.GetById(id);
            return ticketById;
        }
        public async Task AddUser(User user, CancellationToken cancelationToken)
        {
            await userRepository.AddUser(user, cancelationToken);
        }
        public async Task<bool> DeleteUser(int id, CancellationToken cancelationToken)
        {
            return await userRepository.DeleteUser(id, cancelationToken);
        }
        public async Task AddMoneyToUser(int userId, double amount)
        {
            await userRepository.AddMoneyToUser(userId, amount);
        }
    }
}
