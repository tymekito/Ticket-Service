using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BookApi.Entities;
using BookApi.IRepository;
using System;

namespace BookApi.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext dbContext;
        public BookRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<Book>> GetAll(CancellationToken cancelationToken)
        {
            return await dbContext
                .Books
                .ToListAsync(cancelationToken);
        }
        public async Task<List<Book>> GetTicketListByUserId(int userId, CancellationToken cancelationToken)
        {
            return await dbContext
                .Books
                .Where( t => t.UserId == userId)
                .ToListAsync();
        }
        public async Task AddBook(Book ticket, CancellationToken cancelationToken)
        {
            await dbContext
                .Books
                .AddAsync(ticket, cancelationToken);

            await dbContext.SaveChangesAsync(cancelationToken);
        }
        public async Task<bool> ReturnBook(int id, CancellationToken cancelationToken)
        {
            var book = await dbContext
                .Books
                .FirstOrDefaultAsync(e => e.Id == id);
            if (book == null)
            {
                return false;
            }
            book.ExpirationDate = null;
            book.UserId = null;
            dbContext.Books.Update(book);
            await dbContext.SaveChangesAsync(cancelationToken);
            return true;
        }
        public async Task<bool> BorrowBook(int id, int userId, CancellationToken cancelationToken)
        {
            var book = await dbContext
                .Books
                .FirstOrDefaultAsync(e => e.Id == id);
            if (book == null)
            {
                return false;
            }
            book.ExpirationDate = DateTime.Now.AddDays(7);
            book.UserId = userId;
            dbContext.Books.Update(book);
            await dbContext.SaveChangesAsync(cancelationToken);
            return true;
        }
    }
}
