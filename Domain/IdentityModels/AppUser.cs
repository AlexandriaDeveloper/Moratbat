using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Domain.IdentityModels;
public class AppUser : IdentityUser
{
    [Required]
    [MaxLength(100)]
    public string DisplayName { get; set; } = string.Empty;
    [Required]
    [MaxLength(100)]
    public string ProfileImage { get; set; } = string.Empty;
    [MaxLength(14), MinLength(14)]
    public string NationalId { get; set; }

    public ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
}
