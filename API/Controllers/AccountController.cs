using System;
using System.Security.Claims;
using API.DTOs;
using API.Helper.Attributes;
using API.Services;
using Domain;
using Microsoft.AspNetCore.Authorization;
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

        public AccountController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<AppUser> signInManager, TokenService tokenService)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
            this._signInManager = signInManager;
            this._tokenService = tokenService;
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByNameAsync(loginDto.UserName);


            if (user == null) return Unauthorized();
            var userRoles = await _userManager.GetRolesAsync(user);
            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if (result.Succeeded)
            {
                return CreateUserObject(user, userRoles);

            }
            return Unauthorized();
        }
        [AuthorizeRoles(RolesList.Admin)]
        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register([FromBody] RegisterDto registerDto)
        {
            if (await _userManager.Users.AnyAsync(x => x.UserName == registerDto.UserName) || await _userManager.Users.AnyAsync(x => x.Email == registerDto.Email))
            {
                return BadRequest("Email Taken");
            }
            var user = new AppUser
            {
                DisplayName = registerDto.DisplayName,
                Email = registerDto.Email,
                UserName = registerDto.UserName,
                ProfileImage = registerDto.ProfileImage
            };
            var result = await _userManager.CreateAsync(user, registerDto.Password);


            if (result.Succeeded)
            {
                return CreateUserObject(user, registerDto.UserRoles);



            }
            return BadRequest("Problem While Register User");
        }

        [HttpGet("getCurrentUser")]
        public async Task<ActionResult<UserDto>> getCurrentUser()
        {
            var user = await _userManager.FindByNameAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var userRoles = await _userManager.GetRolesAsync(user);

            return CreateUserObject(user, userRoles);

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

        private UserDto CreateUserObject(AppUser registerDto, IList<string> userRoles)
        {

            return new UserDto(

                registerDto.DisplayName,
                _tokenService.CreateToken(registerDto, userRoles),
                 registerDto.UserName,
                registerDto.ProfileImage
               );
        }

    }
}