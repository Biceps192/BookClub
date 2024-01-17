using BookClubApi.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookClubApi.Controllers
{
    [DynamicRoleCheck("Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClubSettingsController : ControllerBase
    {
        [HttpGet(Name = "string")]
        public string Get()
        {
            return "string";
        }
    }
}
