using BookClubApi.Models;
using BookClubApi.Service;
using Microsoft.AspNetCore.Mvc;

namespace BookClubApi.Controllers
{
    [ApiController]
    [Route("/book")]
    public class BookController: ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        [Route("/GetBooks")]
        public ActionResult<IEnumerable<Book>> GetBooks()
        {
            var books = _bookService.GetBooks();

            return Ok(books);
        }

        [HttpGet]
        [Route("/GetBookById")]
        public ActionResult<Book> GetBookById(int id)
        {
            var book = _bookService.GetBookById(id);

            return Ok(book);
        }
    }
}
