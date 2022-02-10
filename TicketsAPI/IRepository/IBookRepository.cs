using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BookApi.Entities;

namespace BookApi.IRepository
{
    public interface IBookRepository
    {
        public Task<IEnumerable<Book>> GetAll(CancellationToken cancelationToken);
        public Task<List<Book>> GetTicketListByUserId(int id, CancellationToken cancelationToken);
        public Task AddBook(Book ticket, CancellationToken cancelationToken);
        public Task<bool> ReturnBook(int id, CancellationToken cancelationToken);
        public Task<bool> BorrowBook(int id, int userId , CancellationToken cancelationToken);

    }
}
