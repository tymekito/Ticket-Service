
using System.Threading.Tasks;
using TicketsAPI.Models;

namespace TicketsAPI.IServices
{
    public interface IAuthService
    {
        Task<ResponceAuth> AuthenticateUser(string login, string password);
    }
}
