using BookClubApi.Data;
using BookClubApi.IRepo;
using BookClubApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BookClubApi.Repo
{
    public class MemberProfileRepo: IMemberProfileRepo
    {
        private readonly BookContext _bookContext;

        public MemberProfileRepo(BookContext bookContext)
        {
            _bookContext = bookContext;
        }

        public void AddGenreToMemberProfile(int memberProfileId, int genreId)
        {
            var existingEntry = _bookContext.MemberProfileGenres
            .FirstOrDefault(mpGenre => mpGenre.MemberProfileId == memberProfileId && mpGenre.GenreId == genreId);

            if (existingEntry == null)
            {
                _bookContext.MemberProfileGenres.Add(new MemberProfileGenre { MemberProfileId = memberProfileId, GenreId = genreId });
            }
            SaveChanges();
        }

        public MemberProfile GetMemberProfileById(int id)
        {
            return _bookContext.MemberProfiles.FirstOrDefault(x => x.Id == id);
        }

        public void CreateMemberProfile(MemberProfile memberProfile)
        {
            _bookContext.MemberProfiles.Add(memberProfile);
            SaveChanges();
        }

        public MemberProfile GetMemberProfile(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Genre> GetGenresByMemberProfileId(int memberProfileId)
        {
            return _bookContext.MemberProfileGenres.Where(mpGenre => mpGenre.MemberProfileId == memberProfileId).Select(mpGenre => mpGenre.Genre);
        }

        public bool SaveChanges()
        {
            return (_bookContext.SaveChanges() >= 0);
        }
    }
}
