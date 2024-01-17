using BookClubApi.Models;

namespace BookClubApi.IRepo
{
    public interface IBookRating
    {
        IEnumerable<BookRating> GetAllBookRatings();
        void AddBookRating(BookRating bookRating);
        void AddBookReview(BookRating bookRating);
        IEnumerable<BookRating> GetBookRatingsByBookId(int bookId);
    }
}
