namespace BookClubApi.Models
{
    public class MemberProfile: BaseEntity
    {
        public string MemberName { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
