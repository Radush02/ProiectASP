using Microsoft.AspNetCore.Mvc;
using ProiectASP.Services;
using ProiectASP.Repositories;
using ProiectASP.Models.DTOs.UserDTOs;
using Microsoft.AspNetCore.Authorization;

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
            var result = await _userService.LoginAsync(login);

            if (result.Key.Succeeded)
            {
                return Ok(new {Token=result.Value, Message = $"Autentificat la {login.UserName}" });
            }
            else if(result.Key.IsLockedOut) //Nu ajunge pana aici inca
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
        [HttpPost("admin"),Authorize(Roles ="Admin")]
        public async Task<IActionResult> MakeAdmin(string username)
        {
           await _userService.MakeAdmin(username);
            return Ok(new {Message=$"{username} este admin."});
        }
    }
}
