using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ToDoListApplication.Business.DTO;
using ToDoListApplication.Business.Services.Interface;

namespace ToDoListApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _user;
        private readonly SignInManager<IdentityUser> _signin;
        private readonly ITokenService _tokenService;

        public AccountController(UserManager<IdentityUser> user, SignInManager<IdentityUser> signin,ITokenService tokenService)
        {
            _user = user;
            _signin = signin;
            _tokenService = tokenService;
        }

        [HttpGet("test")]
        [Authorize]
        public async Task<ActionResult> test()
        {
            return Ok(new { message = "Authorized" });
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _user.FindByEmailAsync(loginDto.Email);

            if (user == null)
                return Unauthorized();

            var result = await _signin.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded)
                return Unauthorized();

            return new UserDto {
                UserId = user.Id,
                Email = loginDto.Email,
                Password = loginDto.Password,
                Token = _tokenService.CreateToken(user)};
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            var user = new IdentityUser
            {
                Email = registerDto.Email,
                UserName = registerDto.UserName
            };

            var emailexist = await _user.FindByEmailAsync(user.Email);

            if (emailexist != null)
                return BadRequest(new { message = "Email existed!" });

            var result = await _user.CreateAsync(user, registerDto.Password);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return new UserDto
            {
                UserId = user.Id,
                Email = user.Email,
                Password = registerDto.Password,
                Token = _tokenService.CreateToken(user)
            };
        }
    }
}
