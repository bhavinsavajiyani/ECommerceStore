using System.Security.Claims;
using AutoMapper;
using EComm_Store_API.DTOs;
using EComm_Store_API.Errors;
using EComm_Store_API.Extensions;
using EComm_Store_Core.Entities.Identity;
using EComm_Store_Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EComm_Store_API.Controllers
{
    public class AccountController : BaseAPIController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public AccountController(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            ITokenService tokenService,
            IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<UserDTO>> GetCurrentUser()
        {
            var user = await _userManager.FindUserByEmailFromClaimsPrincipal(User);

            return new UserDTO
            {
                Email = user.Email,
                Token = _tokenService.GenerateToken(user),
                DisplayName = user.DisplayName,
            };
        }

        // Useful for async validation on client-side to check if email already exists on server (Cannot allow new user to register with email that already exists)
        [HttpGet("emailexists")]
        public async Task<ActionResult<bool>> CheckEmailExistsAsync([FromQuery] string email)
        {
            return await _userManager.FindByEmailAsync(email) != null;
        }

        [Authorize]
        [HttpGet("address")]
        public async Task<ActionResult<AddressDTO>> GetUserAddress()
        {
            // var email = HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email);

            var user = await _userManager.FindUserByClaimsPrincipalWithAddressAsync(User);

            return _mapper.Map<Address, AddressDTO>(user.Address);
        }

        [Authorize]
        [HttpPut("address")]
        public async Task<ActionResult<AddressDTO>> UpdateUserAddress(AddressDTO address)
        {
            var user = await _userManager.FindUserByClaimsPrincipalWithAddressAsync(User);
            user.Address = _mapper.Map<AddressDTO, Address>(address);

            var result = await _userManager.UpdateAsync(user);
            if(result.Succeeded) return Ok(_mapper.Map<Address, AddressDTO>(user.Address));
            return BadRequest("Couldn't Update the User!");
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
                Token = _tokenService.GenerateToken(user),
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
                Token = _tokenService.GenerateToken(user),
                Email = user.Email
            };
        }
    }
}