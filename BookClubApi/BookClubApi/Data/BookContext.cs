using BookClubApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BookClubApi.Data
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> opt) : base(opt)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<UserClub> UserClub { get; set; }
        public DbSet<MemberProfile> MemberProfiles { get; set; }
        public DbSet<MemberProfileGenre> MemberProfileGenres { get; set; }
        public DbSet<BookRating> BookRatings { get; set; }
        public DbSet<Forum> Forums { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });
        }
    }

}
