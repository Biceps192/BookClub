namespace BookClubApi.Dto.Forum
{
    public class ForumCreateDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int MemberProfileId { get; set; }
    }
}
