using AutoMapper;
using BookClubApi.Dto.Forum;
using BookClubApi.Models;
using BookClubApi.Service;
using Microsoft.AspNetCore.Mvc;

namespace BookClubApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ForumController: ControllerBase
    {
        private readonly IForumService _forumService;
        private readonly IMapper _mapper;

        public ForumController(IForumService forumService, IMapper mapper)
        {
            _forumService = forumService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllDiscussions()
        {
            var forums = _forumService.GetAllForums();
            return Ok(forums);
        }

        [HttpGet("{id}")]
        public IActionResult GetForumById(int id)
        {
            var forum = _forumService.GetForumById(id);

            if (forum == null)
            {
                return NotFound();
            }

            return Ok(forum);
        }

        [HttpPost]
        public ActionResult<ForumReadDto> AddForum([FromBody] ForumCreateDto forum)
        {
            var forumModel = _mapper.Map<Forum>(forum);
            if (forum == null)
            {
                return BadRequest();
            }

            _forumService.AddForum(forumModel);
            var forumReadModel = _mapper.Map<ForumReadDto>(forumModel);

            return Ok("Forum added");
        }
    }
}
