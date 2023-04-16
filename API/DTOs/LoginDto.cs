using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public record LoginDto(string UserName, string Password);
    public record RegisterDto(
    [Required] string UserName,
    [Required, EmailAddress] string Email,
    [Required] string DisplayName,
    [Required, MaxLength(12), MinLength(4)] string Password,
    [Required] string ProfileImage, [Required] IList<string> UserRoles);

    public record UserDto(string DisplayName, string Token, string UserName, string ProfileImage);
}