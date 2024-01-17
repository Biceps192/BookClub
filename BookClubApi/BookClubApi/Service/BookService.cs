using BookClubApi.IRepo;
using BookClubApi.Models;
using BookClubApi.Repo;

namespace BookClubApi.Service
{
    public interface IBookService
    {
        IEnumerable<Book> GetBooks();
        Book GetBookById(int id);
        IEnumerable<Book> RecommendBooksByGenres(int id);
    }

    public class BookService: IBookService
    {
        private readonly IBookRepo _repo;

        public BookService(IBookRepo repo)
        {
            _repo = repo;
        }

        public Book GetBookById(int id)
        {
            return _repo.GetBook(id);
        }

        public IEnumerable<Book> GetBooks()
        {
            return _repo.GetBooks();
        }

        public IEnumerable<Book> RecommendBooksByGenres(int id)
        {
            return _repo.RecommendBooksByGenres(id);
        }
    }
}
