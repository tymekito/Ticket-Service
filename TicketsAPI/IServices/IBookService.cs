using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BookApi.Entities;


namespace BookApi.IServices
{
    public interface IBookService
    {
        public Task<IEnumerable<Book>> GetAll(CancellationToken cancelationToken);
        public Task<List<Book>> GetTicketListByUserId(int id, CancellationToken cancelationToken);
        public Task AddBook(Book book, CancellationToken cancelationToken);
        public Task<bool> ReturnBook(int id, CancellationToken cancelationToken);
        public Task<bool> BorrowBook(int id, int userId ,CancellationToken cancelationToken);

    }
}
