using System.Text.Json.Serialization;

namespace Domain.IdentityModels
{
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
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiration { get; set; }
    }
}
