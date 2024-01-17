using BookClubApi.Data;
using BookClubApi.IRepo;
using BookClubApi.Models;

namespace BookClubApi.Repo
{
    public class BookRatingRepo : IBookRating
    {
        private readonly BookContext _context;

        public BookRatingRepo(BookContext context)
        {
            _context = context;
        }

        public void AddBookRating(BookRating bookRating)
        {
            _context.BookRatings.Add(bookRating);
            _context.SaveChanges();
        }

        public void AddBookReview(BookRating bookRating)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BookRating> GetAllBookRatings()
        {
            return _context.BookRatings.ToList();
        }

        public IEnumerable<BookRating> GetBookRatingsByBookId(int bookId)
        {
            return _context.BookRatings.Where(x => x.BookId == bookId).ToList();
        }
    }
}
