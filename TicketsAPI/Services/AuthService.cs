
using AutoMapper;
using System.Threading.Tasks;
using TicketsAPI.IRepository;
using TicketsAPI.IServices;
using TicketsAPI.Models;

namespace TicketsAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        public AuthService(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }
        public async Task<ResponceAuth> AuthenticateUser(string login, string password)
        {
            var user = await this.userRepository.GetByLogin(login);

            if(user != null)
            {
                user.Password.Equals(password);
                var result = this.mapper.Map<ResponceAuth>(user);
                return result;
            }
            return null;
        }
    }
}
