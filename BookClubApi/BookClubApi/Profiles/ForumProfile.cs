using AutoMapper;
using BookClubApi.Dto.BookRating;
using BookClubApi.Dto.Forum;
using BookClubApi.Models;

namespace BookClubApi.Profiles
{
    public class ForumProfile: Profile
    {
        public ForumProfile()
        {
            CreateMap<Forum, ForumReadDto>();
            CreateMap<ForumCreateDto, Forum>();
        }
    }
}
