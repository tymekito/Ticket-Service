using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BookApi.Entities;
using BookApi.IServices;
using BookApi.Models;

namespace BookApi.Controllers
{
    [Route("api/book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService service;
        private readonly IMapper mapper;
        public BookController(IBookService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyCollection<Book>>> GetTickets(CancellationToken cancelationToken)
        {
            var ticket = await service.GetAll(cancelationToken);
            var result = ticket.ToList().Select(e => mapper.Map<BookViewModel>(e));
            return Ok(result);
        }
        [HttpGet("{userId}")]
        public async Task<ActionResult<IReadOnlyCollection<Book>>> GetTicketsForUser([FromRoute] int userId, CancellationToken cancelationToken)
        {
            var tickets = await service.GetTicketListByUserId(userId, cancelationToken);
            var result = tickets.ToList().Select(e => mapper.Map<BookViewModel>(e));
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> AddBook(Book model, CancellationToken cancelationToken)
        {
            await service.AddBook(model, cancelationToken);
            return Ok();
        }
        [HttpPost("{bookId}")]
        public async Task<ActionResult> ReturnBook([FromRoute] int bookId, CancellationToken cancelationToken)
        {
            var result = await service.ReturnBook(bookId, cancelationToken);
            return Ok(result);
        }
        [HttpPost("{bookId}/{userId}")]
        public async Task<ActionResult> BorrowBook([FromRoute] int bookId, [FromRoute] int userId, CancellationToken cancelationToken)
        {
            var result = await service.BorrowBook(bookId, userId,cancelationToken);
            return Ok(result);
        }
    }
}
