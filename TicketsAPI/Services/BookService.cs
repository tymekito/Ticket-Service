using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BookApi.Entities;
using BookApi.IRepository;
using BookApi.IServices;

namespace BookApi.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository ticketRepository;
        public BookService(IBookRepository ticketRepository)
        {
            this.ticketRepository = ticketRepository;
        }
        public async Task<IEnumerable<Book>> GetAll(CancellationToken cancelationToken)
        {
            var tickets = await ticketRepository.GetAll(cancelationToken);
            return tickets;
        }
        public async Task<List<Book>> GetTicketListByUserId(int userId, CancellationToken cancelationToken)
        {
            var ticketById = await ticketRepository.GetTicketListByUserId(userId, cancelationToken);
            return ticketById;
        }
        public async Task AddBook(Book book, CancellationToken cancelationToken)
        {
            await ticketRepository.AddBook(book, cancelationToken);
        }
        public async Task<bool> ReturnBook(int id, CancellationToken cancelationToken)
        {
            return await ticketRepository.ReturnBook(id, cancelationToken);
        }
        public async Task<bool> BorrowBook(int id, int userId ,CancellationToken cancelationToken)
        {
            return await ticketRepository.BorrowBook(id, userId, cancelationToken);
        }

    }
}
