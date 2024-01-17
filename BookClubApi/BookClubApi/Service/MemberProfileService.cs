using BookClubApi.IRepo;
using BookClubApi.Models;

namespace BookClubApi.Service
{
    public interface IMemberProfileService
    {
        void CreateMemberProfile(MemberProfile memberProfile);
        void AddGenreToMemberProfile(int memberProfileId, int genreId);
        bool SaveChanges();
        MemberProfile GetMemberProfileById(int id);
        IEnumerable<Book> RecommendBooksByGenres(int memberProfileId);
    }

    public class MemberProfileService : IMemberProfileService
    {
        private readonly IMemberProfileRepo _repo;
        private readonly IBookService _bookService;

        public MemberProfileService(IMemberProfileRepo repo, IBookService bookService)
        {
            _repo = repo;
            _bookService = bookService;
        }

        public MemberProfile GetMemberProfileById(int id)
        {
            return _repo.GetMemberProfileById(id);
        }

        public void AddGenreToMemberProfile(int memberProfileId, int genreId)
        {
            _repo.AddGenreToMemberProfile(memberProfileId, genreId);
        }

        public void CreateMemberProfile(MemberProfile memberProfile)
        {
            _repo.CreateMemberProfile(memberProfile);
        }

        public IEnumerable<Book> RecommendBooksByGenres(int memberProfileId)
        {
            var genres = _repo.GetGenresByMemberProfileId(memberProfileId);

            if (genres == null || !genres.Any())
            {
                return null;
            }

            // Пример: Рекомендовать книги только из выбранных жанров
            return _bookService.GetBooks().Where(book => genres.Any(genre => genre.Id == book.GenreId));
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
