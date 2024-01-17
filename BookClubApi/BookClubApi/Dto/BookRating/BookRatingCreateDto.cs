namespace BookClubApi.Dto.BookRating
{
    public class BookRatingCreateDto
    {
        public int BookId { get; set; }
        public int Rating { get; set; }
        public string Review { get; set; }
        public int MemberProfileId { get; set; }
    }
}
