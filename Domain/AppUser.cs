using Microsoft.AspNetCore.Identity;

namespace Domain;
public class AppUser : IdentityUser
{

    public string DisplayName { get; set; } = string.Empty;
    public string ProfileImage { get; set; } = string.Empty;
}
