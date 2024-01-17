using AutoMapper;
using BookClubApi.Dto.MemberProfile;
using BookClubApi.Models;
using BookClubApi.Service;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace BookClubApi.Controllers
{

    [ApiController]
    [Route("/member")]
    public class MemberProfileController : ControllerBase
    {
        private readonly IMemberProfileService _memberProfileService;
        private readonly IMapper _mapper;

        public MemberProfileController(IMemberProfileService memberProfileService, IMapper mapper)
        {
            _memberProfileService = memberProfileService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult GetMemberProfileById(int id)
        {
            var memberProfile = _memberProfileService.GetMemberProfileById(id);

            if (memberProfile == null)
            {
                return NotFound();
            }

            return Ok(memberProfile);
        }

        [HttpPost]
        [Route("/CreateMemberProfile")]
        public ActionResult<MemberProfileReadDto> CreateMemberProfile(MemberProfileCreateDto memberProfile)
        {
            var memberModel = _mapper.Map<MemberProfile>(memberProfile);

            if (memberProfile == null)
            {
                return BadRequest();
            }

            _memberProfileService.CreateMemberProfile(memberModel);
            var memberReadModel = _mapper.Map<MemberProfileReadDto>(memberModel);

            return CreatedAtAction(nameof(CreateMemberProfile), new { id = memberReadModel.Id }, memberProfile);
        }

        [HttpPost]
        [Route("/AddGenre")]
        public ActionResult AddFavouriteGenre([FromBody] AddFavouriteGenreDto genreDto)
        {
            _memberProfileService.AddGenreToMemberProfile(genreDto.Id, genreDto.GenreId);

            return Ok("Added sucesfuly");
        }

        [HttpGet("{id}/recommendationsByGenres")]
        public IActionResult GetRecommendedBooksByGenres(int id)
        {
            var recommendedBooks = _memberProfileService.RecommendBooksByGenres(id);

            if (recommendedBooks == null)
            {
                return NotFound();
            }

            return Ok(recommendedBooks);
        }
    }
}
