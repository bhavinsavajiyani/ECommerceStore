using EComm_Store_API.DTOs;
using EComm_Store_API.Errors;
using EComm_Store_Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EComm_Store_API.Controllers
{
    public class AccountController : BaseAPIController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> Login(LoginDTO loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null) return Unauthorized(new APIErrorResponse(401));

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if(!result.Succeeded) return Unauthorized(new APIErrorResponse(401));

            return new UserDTO
            {
                Email = user.Email,
                Token = "This will be a Token",
                DisplayName = user.DisplayName,
            };
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDTO>> Register(RegisterDTO registerDto)
        {
            var user = new AppUser
            {
                DisplayName = registerDto.DisplayName,
                Email = registerDto.Email,
                UserName = registerDto.Email
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if(!result.Succeeded) return BadRequest(new APIErrorResponse(400));

            return new UserDTO
            {
                DisplayName = user.DisplayName,
                Token = "This is a Token",
                Email = user.Email
            };
        }
    }
}