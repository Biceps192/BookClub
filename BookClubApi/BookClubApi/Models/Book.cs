namespace BookClubApi.Models
{
    public class Book: BaseEntity
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public string Synopsis { get; set; }
    }
}
