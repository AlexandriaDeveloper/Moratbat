using System;
using System.Security.Claims;
using API.DTOs;
using API.Helper.Attributes;
using API.Services;
using Domain;
using Domain.IdentityModels;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence.Constants;

namespace API.Controllers
{

    public class AccountController : BaseApiController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly TokenService _tokenService;
        private readonly IAuthService _authService;

        public AccountController(IMediator mediator, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<AppUser> signInManager, IAuthService authService) : base(mediator)
        {
            this._authService = authService;
            this._userManager = userManager;
            this._roleManager = roleManager;
            this._signInManager = signInManager;

        }
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult> RegisterAsync([FromBody] RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _authService.RegisterAsync(model);
            if (!result.IsAuthenticated)
            {
                return BadRequest(result.Message);
            }
            SetRefreshTokenInCookie(result.RefreshToken, result.RefreshTokenExpiration);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult> LoginAsync([FromBody] LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _authService.LoginAsync(model);
            if (!result.IsAuthenticated)
            {
                return BadRequest(result.Message);
            }
            if (!string.IsNullOrEmpty(result.RefreshToken))
                SetRefreshTokenInCookie(result.RefreshToken, result.RefreshTokenExpiration);

            return Ok(result);
        }

        [Authorize]
        [HttpPost("addUserToRole")]
        public async Task<ActionResult> LoginAsync([FromBody] RoleModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _authService.AddRoleAsync(model);
            if (!string.IsNullOrEmpty(result))
            {
                return BadRequest(result);
            }

            return Ok(model);
        }
        [Authorize]
        [HttpPost("logout")]
        public async Task<ActionResult> LogoutAsync()
        {
            await HttpContext.SignOutAsync(
             CookieAuthenticationDefaults.AuthenticationScheme);

            return Ok();
        }
        [HttpGet("getCurrentUser")]
        public async Task<ActionResult<AuthModel>> GetCurrentUser()
        {
            var user = await _userManager.Users
               .FirstOrDefaultAsync(x => x.UserName == User.FindFirstValue(ClaimTypes.NameIdentifier));

            return await _authService.CurrentUser(user);

        }
        [AllowAnonymous]
        [HttpGet("refreshToken")]
        public async Task<IActionResult> RefreshToken()
        {

            var refreshToken = Request.Cookies["refreshToken"];
            var result = await _authService.RefreshTokenAsync(refreshToken);
            if (!result.IsAuthenticated)
                return BadRequest(result);
            SetRefreshTokenInCookie(result.RefreshToken, result.RefreshTokenExpiration);
            return Ok(result);
        }

        [HttpPost("revokeToken")]
        public async Task<IActionResult> RevokeToken([FromBody] RevokeTokenModel model)
        {
            var token = model.Token ?? Request.Cookies["refreshToken"];
            if (string.IsNullOrEmpty(token))
            {
                return BadRequest("token is required");
            }
            var result = await _authService.RevokeTokenAsync(token);
            if (!result)
                return BadRequest("tokin is invalid ");
            return Ok();
        }
        [AuthorizeRolesAttribute(RolesList.Admin)]
        [HttpGet("getSecretKey")]
        public ActionResult<string> getSecretKey()
        {
            //48p1Nv12wRtbsRAAhJiKS0PliL8Fdv0zO_7PPPGZkkI 
            SecretKeyGenerator key = new SecretKeyGenerator();
            var result = key.GenerateRsaCryptoServiceProviderKey();
            return result;
        }
        private void SetRefreshTokenInCookie(string refreshToken, DateTime expires)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = expires.ToLocalTime()
            };
            Response.Cookies.Append("refreshToken", refreshToken, cookieOptions);
        }
    }
}