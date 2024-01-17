using AutoMapper;
using BookClubApi.Dto.MemberProfile;
using BookClubApi.Models;

namespace BookClubApi.Profiles
{
    public class MemberProfiles: Profile
    {
        public MemberProfiles()
        {
            CreateMap<MemberProfile, MemberProfileReadDto>();
            CreateMap<MemberProfileCreateDto, MemberProfile>();
        }
    }
}
