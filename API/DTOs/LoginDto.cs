using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API.DTOs
{
    public record LoginDto(string UserName, string Password);
    // public record RegisterDto(
    // [Required] string UserName,
    // [Required, EmailAddress] string Email,
    // [Required] string DisplayName,
    // [Required, MaxLength(12), MinLength(4)] string Password,
    // [Required] string ProfileImage, [Required] IList<string> UserRoles);

    //public record UserDto(string DisplayName, string Token, string UserName, string ProfileImage,[JsonIgnore] string? RefreshToken , DateTime RefreshTokenExpiration);


    public class UserDto
    {
        public UserDto(string displayName, string userName, string profileImage, string token, string refreshToken, DateTime refreshTokenExpiration)
        {
            DisplayName = displayName;
            UserName = userName;
            ProfileImage = profileImage;
            Token = token;
            RefreshToken = refreshToken;
            RefreshTokenExpiration = refreshTokenExpiration;
        }

        public string DisplayName { get; set; }
        public string UserName { get; set; }
        public string ProfileImage { get; set; }
        public string Token { get; set; }
        [JsonIgnore]
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiration { get; set; }
    }




    public class AuthModel
    {
        public string? Message { get; set; }
        public bool IsAuthenticated { get; set; }
        public string Username { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string ProfileImage { get; set; }
        public List<string> Roles { get; set; }
        public string Token { get; set; }
        //  public DateTime Expires { get; set; }
        [JsonIgnore]
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiration { get; set; }
    }

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

    public class LoginModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

    }
    public class RoleModel
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        public string RoleName { get; set; }
    }
    public class RevokeTokenModel
    {
        public string? Token { get; set; }
    }
}

