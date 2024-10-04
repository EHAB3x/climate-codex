using ClimateCodex.Server.Models;
using ClimateCodex.Server.Repository;
using Microsoft.AspNetCore.Mvc;

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

        
        [HttpPost]
        public IActionResult CreateUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _userRepo.Add(user);
            return Ok(new { message = "User created successfully" });
        }

        
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
