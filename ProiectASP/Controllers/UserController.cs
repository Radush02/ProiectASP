using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProiectASP.Models;
using ProiectASP.Services;
using Microsoft.EntityFrameworkCore;
using ProiectASP.Models.DTOs.UserDTOs;

namespace ProiectASP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userService;

        public UserController(IUserServices userService)
        {
            _userService = userService;
        }

        // GET: api/user
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserInfoDTO>>> GetUsers()
        {
            var users = await _userService.GetAllUsers();
            return Ok(users);
        }

        // GET: api/user/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserInfoDTO>> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost("createWithPassword")]
        public async Task<IActionResult> CreateWithPassword(FullUserDTO u)
        {
            await _userService.CreateWithPassword(u);
            await _userService.AddAdresa(u);
            return Ok(u);
            
        }
        [HttpGet("Login")]
        public async Task<IActionResult> Login(UserLoginDTO user)
        {
            if(await _userService.Login(user.UserName, user.Parola)==true)
            { 
                return Ok(); 
            }
            return BadRequest();

        }
        // PUT: api/user/5
        [HttpPut]
        public async Task<IActionResult> UpdateUser(FullUserDTO user)
        {

            await _userService.UpdateUser(user);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userService.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }

            await _userService.DeleteUser(id);

            return NoContent();
        }
    }
}
