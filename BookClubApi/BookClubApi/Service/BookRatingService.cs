using BookClubApi.IRepo;
using BookClubApi.Models;

namespace BookClubApi.Service
{
    public interface IBookRatingService
    {
        IEnumerable<BookRating> GetAllBookRatings();
        IEnumerable<BookRating> GetBookRatingsByBookId(int bookId);
        void AddBookRating(BookRating bookRating);
    }

    public class BookRatingService : IBookRatingService
    {
        private readonly IBookRating _bookRating;

        public BookRatingService(IBookRating bookRating)
        {
            _bookRating = bookRating;
        }


        public void AddBookRating(BookRating bookRating)
        {
            _bookRating.AddBookRating(bookRating);
        }

        public IEnumerable<BookRating> GetAllBookRatings()
        {
            return _bookRating.GetAllBookRatings();
        }

        public IEnumerable<BookRating> GetBookRatingsByBookId(int bookId)
        {
            return _bookRating.GetBookRatingsByBookId(bookId);
        }
    }
}
