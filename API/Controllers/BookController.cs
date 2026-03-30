using Application.Contracts.Store;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public async Task<ActionResult<List<BookResponse>>> GetBooks()
        {
            var books = await _bookService.GetAllBooks();

            var response = books.Select(b => new BookResponse
            (b.Id, b.Title, b.Author, b.PublishingHouse,
            b.PublishingYear, b.CountPages, b.Price, b.Binding));

            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Guid>> CraeteBook([FromBody] BookRequest request)
        {
            var (bookId, error) = await _bookService.CreateBook(request);

            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            return Ok(bookId);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Guid>> UpdateBook(Guid id, [FromBody] BookRequest request)
        {
            var (bookId, error) = await _bookService.UpdateBook(id, request);

            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            return Ok(bookId);
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Guid>> DeleteBook(Guid id)
        {
            var bookId = await _bookService.DeleteBook(id);

            return Ok(bookId);
        }
    }
}
