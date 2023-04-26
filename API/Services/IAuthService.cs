using System.Security.Cryptography;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using API.DTOs;
using API.Helper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Persistence.Constants;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using Domain.IdentityModels;

namespace API.Services
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

    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly JWT _jwt;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AuthService(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<AppUser> signInManager, IOptions<JWT> jwt)
        {
            this._roleManager = roleManager;
            this._signInManager = signInManager;
            this._jwt = jwt.Value;
            this._userManager = userManager;

        }

        public async Task<AuthModel> LoginAsync(LoginModel model)
        {
            var authModel = new AuthModel();
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user == null)
            {
                authModel.Message = "أسم المستخدم او  كلمة المرورو خطأ ";
                return authModel;
            }
            if (!await _userManager.CheckPasswordAsync(user, model.Password))
            {
                authModel.Message = "أسم المستخدم او  كلمة المرورو خطأ ";
                return authModel;
            }
            authModel.IsAuthenticated = true;
            authModel = await CreateAuthObjectAsync(user);
            RefreshToken refreshToken;
            if (user.RefreshTokens.Any(t => t.IsActive))
            {
                refreshToken = user.RefreshTokens.FirstOrDefault(t => t.IsActive);
            }
            else
            {
                refreshToken = GenerateRefreshToken();
                user.RefreshTokens.Add(refreshToken);
                await _userManager.UpdateAsync(user);
            }
            authModel.RefreshToken = refreshToken.Token;
            authModel.RefreshTokenExpiration = refreshToken.Expires;
            return authModel;
        }

        public async Task<AuthModel> RegisterAsync(RegisterModel model)
        {
            if (await _userManager.FindByEmailAsync(model.Email) is not null)
            {
                return new AuthModel { Message = "الاميل مسجل من قبل" };
            }
            if (await _userManager.FindByNameAsync(model.Username) is not null)
            {
                return new AuthModel { Message = "اسم المستخدم مسجل من قبل" };
            }
            AppUser user = new AppUser()
            {
                UserName = model.Username,
                Email = model.Email,
                DisplayName = model.DisplayName,
                ProfileImage = model.ProfileImage
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                var errors = string.Empty;
                foreach (var error in result.Errors)
                {
                    errors += error.Description + ",".Trim(',');
                }
                return new AuthModel { Message = errors };
            }

            await _userManager.AddToRoleAsync(user, Enum.GetName(typeof(RolesList), RolesList.User));



            var authModel = await CreateAuthObjectAsync(user);
            return authModel;
        }


        private async Task<JwtSecurityToken> CreateJwtToken(AppUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();
            foreach (var role in roles)
            {
                roleClaims.Add(new Claim("roles", role));
            }
            var claims = new[]{
                new Claim(ClaimTypes.NameIdentifier ,user.UserName),
                new Claim("UUID",user.Id),
                new Claim("displayName",user.DisplayName),
                new Claim("profileImage",user.Email),
                new Claim(JwtRegisteredClaimNames.Iss,_jwt.Issuer),


            }
            .Union(userClaims)
            .Union(roleClaims);
            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._jwt.Key));
            SigningCredentials signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwt.DurationInMinutes),
                signingCredentials: signingCredentials
            );
            return jwtSecurityToken;
        }

        public async Task<string> AddRoleAsync(RoleModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user is null)
                return "Invalid user Id";
            var role = await _roleManager.RoleExistsAsync(model.RoleName);
            if (!role)
                return "Invalid role name";
            if (await _userManager.IsInRoleAsync(user, model.RoleName))
            {
                return "user alredy assigned to this role";
            }
            var result = await _userManager.AddToRoleAsync(user, model.RoleName);
            if (!result.Succeeded)
            {
                return "something went wrong";
            }
            return string.Empty;
        }
        public async Task LogoutAsync()
        {

            await this._signInManager.SignOutAsync();
        }

        private async Task<AuthModel> CreateAuthObjectAsync(AppUser user)
        {

            var jwtSecurityToken = await CreateJwtToken(user);
            return new AuthModel
            {
                Email = user.Email,
                //    Expires = jwtSecurityToken.ValidTo,
                IsAuthenticated = true,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Username = user.UserName,
                ProfileImage = user.ProfileImage,
                DisplayName = user.DisplayName,
                Roles = _userManager.GetRolesAsync(user).Result.ToList()
            };
        }
        private RefreshToken GenerateRefreshToken()
        {
            var random = new byte[32];
            using var generator = RandomNumberGenerator.Create();
            generator.GetBytes(random);
            return new RefreshToken
            {
                Token = Convert.ToBase64String(random),
                Expires = DateTime.UtcNow.ToLocalTime().AddDays(7),
                CreatedOn = DateTime.UtcNow.ToLocalTime()
            };
        }

        public async Task<AuthModel> RefreshTokenAsync(string token)
        {
            var authModel = new AuthModel();
            var user = await _userManager.Users.Include(x => x.RefreshTokens).SingleOrDefaultAsync(x => x.RefreshTokens.Any(t => t.Token == token));
            if (user == null)
            {
                authModel.Message = "invalid token";
                return authModel;
            }
            var refreshToken = user.RefreshTokens.Single(t => t.Token == token);
            if (!refreshToken.IsActive)
            {
                authModel.Message = "inactive  token";
                return authModel;
            }

            refreshToken.Revoked = DateTime.UtcNow.ToLocalTime();
            var newRefreshToken = GenerateRefreshToken();
            user.RefreshTokens.Add(newRefreshToken);
            await _userManager.UpdateAsync(user);
            authModel = await CreateAuthObjectAsync(user);
            authModel.IsAuthenticated = true;
            authModel.RefreshToken = newRefreshToken.Token;

            authModel.RefreshTokenExpiration = newRefreshToken.Expires;


            return authModel;
        }

        public async Task<bool> RevokeTokenAsync(string token)
        {
            var authModel = new AuthModel();
            var user = await _userManager.Users.Include(x => x.RefreshTokens).SingleOrDefaultAsync(x => x.RefreshTokens.Any(t => t.Token == token));
            if (user == null)
                return false;

            var refreshToken = user.RefreshTokens.Single(t => t.Token == token);
            if (!refreshToken.IsActive)
                return false;


            refreshToken.Revoked = DateTime.UtcNow.ToLocalTime();

            await _userManager.UpdateAsync(user);



            return true;

        }

        public async Task<AuthModel> CurrentUser(AppUser user)
        {

            return await CreateAuthObjectAsync(user);

        }


    }
}