using BookClubApi.IRepo;
using BookClubApi.Models;

namespace BookClubApi.Service
{
    public interface IForumService
    {
        IEnumerable<Forum> GetAllForums();
        Forum GetForumById(int id);
        void AddForum(Forum forum);
    }
    public class ForumService : IForumService
    {
        private readonly IForumRepo _repo;

        public ForumService(IForumRepo repo)
        {
            _repo = repo;
        }
        public IEnumerable<Forum> GetAllForums()
        {
            return _repo.GetAllForums();
        }

        public Forum GetForumById(int id)
        {
            return _repo.GetForumById(id);
        }

        public void AddForum(Forum forum)
        {
            _repo.AddForum(forum);
        }
    }
}
