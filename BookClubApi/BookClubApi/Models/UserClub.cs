namespace BookClubApi.Models
{
    public class UserClub: BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int ClubId { get; set; }
        public Club Club { get; set; }
    }
}
