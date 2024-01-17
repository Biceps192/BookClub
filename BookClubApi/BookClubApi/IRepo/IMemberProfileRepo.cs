using BookClubApi.Models;

namespace BookClubApi.IRepo
{
    public interface IMemberProfileRepo
    {
        MemberProfile GetMemberProfile(int id);
        void CreateMemberProfile(MemberProfile memberProfile);
        void AddGenreToMemberProfile(int memberProfileId, int genreId);
        MemberProfile GetMemberProfileById(int id);
        bool SaveChanges();
        IEnumerable<Genre> GetGenresByMemberProfileId(int memberProfileId);

    }
}
