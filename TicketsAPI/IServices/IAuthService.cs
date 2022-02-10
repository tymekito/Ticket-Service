
using System.Threading.Tasks;
using BookApi.Models;

namespace BookApi.IServices
{
    public interface IAuthService
    {
        Task<ResponceAuth> AuthenticateUser(string login, string password);
    }
}
