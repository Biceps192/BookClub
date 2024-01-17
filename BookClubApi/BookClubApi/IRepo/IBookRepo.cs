using BookClubApi.Data;
using BookClubApi.Models;

namespace BookClubApi.IRepo
{
    public interface IBookRepo
    {
        IEnumerable<Book> GetBooks();
        Book GetBook(int id);
        IEnumerable<Book> RecommendBooksByGenres(int id);
    }
}
