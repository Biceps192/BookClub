using BookClubApi.Data;
using BookClubApi.IRepo;
using BookClubApi.Models;

namespace BookClubApi.Repo
{
    public class ForumRepo : IForumRepo
    {
        private readonly BookContext _context;

        public ForumRepo(BookContext context)
        {
            _context = context;
        }

        public void AddForum(Forum forum)
        {
            _context.Forums.Add(forum);
            _context.SaveChanges();
        }

        public IEnumerable<Forum> GetAllForums()
        {
            return _context.Forums.ToList();
        }

        public Forum GetForumById(int id)
        {
            return _context.Forums.FirstOrDefault(x => x.Id == id);
        }
    }
}
