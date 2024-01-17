using AutoMapper;
using BookClubApi.Dto.BookRating;
using BookClubApi.Dto.MemberProfile;
using BookClubApi.Models;
using BookClubApi.Service;
using Microsoft.AspNetCore.Mvc;

namespace BookClubApi.Controllers
{
    [ApiController]
    [Route("/bookRating")]
    public class BookRatingController: ControllerBase
    {
        private readonly IBookRatingService _bookService;
        private readonly IMapper _mapper;

        public BookRatingController(IBookRatingService bookService, IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllBookRatings()
        {
            var bookRatings = _bookService.GetAllBookRatings();
            return Ok(bookRatings);
        }

        [HttpGet("byBook/{bookId}")]
        public IActionResult GetBookRatingsByBookId(int bookId)
        {
            var bookRatings = _bookService.GetBookRatingsByBookId(bookId);
            return Ok(bookRatings);
        }

        [HttpPost]
        public ActionResult<BookRatingReadDto> AddBookRating([FromBody] BookRatingCreateDto bookRating)
        {
            var bookRatingModel = _mapper.Map<BookRating>(bookRating);
            if (bookRating == null)
            {
                return BadRequest();
            }

            _bookService.AddBookRating(bookRatingModel);
            var bookRatingReadModel = _mapper.Map<BookRatingReadDto>(bookRatingModel);

            return Ok("Added");
        }
    }
}
