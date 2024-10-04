using ClimateCodex.Server.Models;
using ClimateCodex.Server.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ClimateCodex.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase // Use ControllerBase for APIs
    {
        private readonly IUserRepo _userRepo;

        public UserController(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        // Get all users (returns JSON)
        [HttpGet]
        public JsonResult GetAllUsers()
        {
            var users = _userRepo.GetAll();
            return new JsonResult(users);
        }

        // Get user by ID (returns JSON)
        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _userRepo.GetById(id);
            if (user == null)
                return NotFound();

            return Ok(user); // Returns JSON by default
        }

        // Create a new user (returns JSON)
        [HttpPost]
        public IActionResult CreateUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _userRepo.Add(user);
            return Ok(new { message = "User created successfully" });
        }

        // Update user (returns JSON)
        [HttpPut("{id}")]
        public IActionResult EditUser(int id, [FromBody] User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingUser = _userRepo.GetById(id);
            if (existingUser == null)
                return NotFound();

            _userRepo.Update(user);
            return Ok(new { message = "User updated successfully" });
        }

        // Delete user (returns JSON)
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = _userRepo.GetById(id);
            if (user == null)
                return NotFound();

            _userRepo.DeleteById(id);
            return Ok(new { message = "User deleted successfully" });
        }
    }
}
