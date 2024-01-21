using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProiectASP.Models;
using ProiectASP.Services;
using Microsoft.EntityFrameworkCore;

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
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _userService.GetAllUsers();
            return Ok(users);
        }

        // GET: api/user/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // POST: api/user
        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(User user)
        {
            await _userService.CreateUser(user);

            return CreatedAtAction(nameof(GetUserById), new { id = user.ID }, user);
        }
        [HttpPost("createWithPassword")]
        public async Task<IActionResult> CreateWithPassword(string username, string name, string password)
        {

                int highestUserId = _userService.getHighestUserID();
                var newUser = new User
                {
                    ID = highestUserId + 1,
                    UserName = username,
                    Nume = name,
                };
                await _userService.CreateWithPassword(newUser, password);
               return Ok(newUser);
            
        }
        [HttpGet("Login")]
        public async Task<IActionResult> Login(string username,string password)
        {
            if(await _userService.Login(username, password)==true)
            { 
                return Ok(); 
            }
            return BadRequest();

        }
        // PUT: api/user/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, User user)
        {
            if (id != user.ID)
            {
                return BadRequest();
            }

            await _userService.UpdateUser(user);

            return NoContent();
        }

        // DELETE: api/user/5
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
