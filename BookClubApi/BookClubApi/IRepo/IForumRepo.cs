using BookClubApi.Models;

namespace BookClubApi.IRepo
{
    public interface IForumRepo
    {
        IEnumerable<Forum> GetAllForums();
        Forum GetForumById(int id);
        void AddForum(Forum forum);
    }
}
