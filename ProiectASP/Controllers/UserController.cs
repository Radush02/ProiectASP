using Microsoft.AspNetCore.Mvc;
using ProiectASP.Services;
using ProiectASP.Repositories;
using ProiectASP.Models.DTOs.UserDTOs;

namespace ProiectASP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userService;
        private readonly IUserRepository _userRepository;
        public UserController(IUserServices userService,IUserRepository userRepository)
        {
            _userService = userService;
            _userRepository = userRepository;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(FullUserDTO user)
        {

            var result = await _userService.RegisterAsync(user);

                if (result.Succeeded)
                {
                    return Ok();
                }
                else
                {
                    var errors = result.Errors.Select(e => e.Description);
                    return BadRequest(errors);
                }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDTO login)
        {
            var result = await _userService.LoginAsync(login.UserName, login.Parola, login.Remember);

            if (result.Succeeded)
            {
                return Ok(new { Message = $"Autentificat la {login.UserName}" });
            }
            else if(result.IsLockedOut)
            {
                return BadRequest("Ai gresit parola de prea multe ori. Contul este blocat.");
            }
            else
            {
                return BadRequest("Parola / user gresit.");
            }
        }
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _userService.LogoutAsync();
            return Ok(new { Message = "Deconectat cu succes." });
        }
        [HttpPost("change")]
        public async Task<IActionResult> ChangePassword(UserChangePassDTO user)
        {

            var result = await _userService.ChangePasswordAsync(user);

            if (result.Succeeded)
            {
                return Ok(new { Message = "Parola schimbata cu succes." });
            }
            else
            {
                return BadRequest("Nu s-a putut schimba parola.");
            }
        }
    }
}
