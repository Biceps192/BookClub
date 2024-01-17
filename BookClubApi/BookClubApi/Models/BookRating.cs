namespace BookClubApi.Models
{
    public class BookRating: BaseEntity
    {
        private const int MinRating = 0;
        private const int MaxRating = 10;
        private int rating;

        public int BookId { get; set; }
        public Book Book { get; set; }
        public int MemberProfileId { get; set; }
        public MemberProfile Member { get; set; }
        public int Rating { get { return rating; } 
            set 
            { 
                rating = (value < MinRating) ? MinRating : (value > MaxRating) ? MaxRating : value;
            } }
        public string Review { get; set; }
    }
}
