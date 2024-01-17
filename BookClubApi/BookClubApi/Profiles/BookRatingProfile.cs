using AutoMapper;
using BookClubApi.Dto.BookRating;
using BookClubApi.Models;

namespace BookClubApi.Profiles
{
    public class BookRatingProfile: Profile
    {
        public BookRatingProfile()
        {
            CreateMap<BookRating, BookRatingReadDto>();
            CreateMap<BookRatingCreateDto, BookRating>();
        }
    }
}
