
using Domain.IdentityModels;

namespace Domain.Services
{
    public interface IAuthService
    {
        Task<AuthModel> RegisterAsync(RegisterModel model);
        Task<AuthModel> LoginAsync(LoginModel model);

        Task<AuthModel> CurrentUser(AppUser user);
        Task<string> AddRoleAsync(RoleModel model);
        Task<AuthModel> RefreshTokenAsync(string token);
        Task LogoutAsync();
        Task<bool> RevokeTokenAsync(string token);
    }
}