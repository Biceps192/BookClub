namespace BookClubApi.Models
{
    public class MemberProfileGenre: BaseEntity
    {
        public int MemberProfileId { get; set; }
        public MemberProfile MemberProfile { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }

    }
}
