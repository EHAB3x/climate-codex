using ClimateCodex.Server.Models;
using ClimateCodex.Server.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ClimateCodex.Server.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepo _userRepo;

        public UserController(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        
        public IActionResult Index()
        {
            var users = _userRepo.GetAll();
            return View(users);
        }

        
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        public IActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                _userRepo.Add(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }

        
        public IActionResult Edit(int id)
        {
            var user = _userRepo.GetById(id);
            if (user == null)
                return NotFound();

            return View(user);
        }

        
        [HttpPost]
        public IActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                _userRepo.Update(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }

        
        public IActionResult Delete(int id)
        {
            var user = _userRepo.GetById(id);
            if (user == null)
                return NotFound();

            return View(user);
        }

        
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var user = _userRepo.GetById(id);
            if (user == null)
                return NotFound();

            _userRepo.DeleteById(id);
            return RedirectToAction("Index");
        }

        
        public IActionResult Details(int id)
        {
            var user = _userRepo.GetById(id);
            if (user == null)
                return NotFound();

            return View(user);
        }
    }
}