using System.ComponentModel.DataAnnotations;

namespace BookClubApi.Dto.Auth
{
    public class LoginModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
