namespace BookClubApi.Models
{
    public class Forum: BaseEntity
    {
        public Forum()
        {
            CreatedAt = DateTime.Now;
        }

        public string Title { get; set; }
        public string Content { get; set; }
        public int MemberProfileId { get; set; }
        public MemberProfile Member { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
