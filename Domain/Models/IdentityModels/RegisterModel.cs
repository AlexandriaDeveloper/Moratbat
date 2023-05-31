using System.ComponentModel.DataAnnotations;

namespace Domain.IdentityModels
{
    public class RegisterModel
    {
        [Required]
        public string DisplayName { get; set; }
        [Required]
        public string ProfileImage { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
    }
}

