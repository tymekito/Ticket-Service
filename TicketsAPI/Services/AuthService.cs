
using AutoMapper;
using System.Threading.Tasks;
using BookApi.IRepository;
using BookApi.IServices;
using BookApi.Models;

namespace BookApi.Services
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
