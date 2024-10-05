using ClimateCodex.Server.Models;
using ClimateCodex.Server.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ClimateCodex.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo _userRepo;

        public UserController(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpGet]
        public JsonResult GetAllUsers()
        {
            var users = _userRepo.GetAll();
            return new JsonResult(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _userRepo.GetById(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost("Register")]
        public IActionResult RegisterUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (_userRepo.GetAll().Any(u => u.Email == user.Email))
                return BadRequest(new { message = "Email is already registered." });

            if (_userRepo.GetAll().Any(u => u.Username == user.Username))
                return BadRequest(new { message = "Username is already taken." });

            _userRepo.Add(user);
            return Ok(new { message = "User registered successfully" });
        }

        [HttpPut("{id}")]
        public IActionResult EditUser(int id, [FromBody] User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingUser = _userRepo.GetById(id);
            if (existingUser == null)
                return NotFound();

            existingUser.Email = user.Email;
            existingUser.Username = user.Username;

            _userRepo.Update(existingUser);
            return Ok(new { message = "User updated successfully" });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = _userRepo.GetById(id);
            if (user == null)
                return NotFound();

            _userRepo.DeleteById(id);
            return Ok(new { message = "User deleted successfully" });
        }

        [HttpPost("ValidateUser")]
        public IActionResult ValidateUser([FromBody] User user)
        {
            var existingUser = _userRepo.GetAll()
                .FirstOrDefault(u => u.Email == user.Email && u.Username == user.Username);

            if (existingUser == null)
            {
                return BadRequest(new { message = "The email or username may be wrong." });
            }

            return Ok(existingUser);
        }
    }
}
