using BookClubApi.Data;
using BookClubApi.IRepo;
using BookClubApi.Models;

namespace BookClubApi.Repo
{
    public class BookRepo: IBookRepo
    {
        private readonly BookContext _context;

        public BookRepo(BookContext context)
        {
            _context = context;
        }

        public Book GetBook(int id)
        {
            return _context.Books.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Book> GetBooks()
        {
            return _context.Books.ToList();
        }
        public IEnumerable<Book> RecommendBooksByGenres(int id)
        {
            var allBooks = GetBooks();

            var recommendedBooks = allBooks.Where(x => x.GenreId == id).ToList();

            return recommendedBooks;
        }
    }
}
