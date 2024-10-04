using Microsoft.AspNetCore.Mvc;
using ClimateCodex.Server.Data; 
using ClimateCodex.Server.Models;
using System.Collections.Generic;
using ClimateCodex.Server.Repository;
using System.Linq;

namespace ClimateCodex.Server.Controllers
{
    public class GHGTypeController : Controller
    {
        private readonly IGHGTypeRepo _repo;

        public GHGTypeController(IGHGTypeRepo repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            var ghgTypes = _repo.GetAllGHGTypes();
            return View(ghgTypes);
        }

        
        public IActionResult Details(int id)
        {
            var ghgType = _repo.GetGHGTypeById(id);
            if (ghgType == null)
            {
                return NotFound();
            }
            return View(ghgType);
        }

        
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(GHGType ghgType)
        {
            if (ModelState.IsValid)
            {
                _repo.AddGHGType(ghgType);
                return RedirectToAction(nameof(Index));
            }
            return View(ghgType);
        }

        
        public IActionResult Edit(int id)
        {
            var ghgType = _repo.GetGHGTypeById(id);
            if (ghgType == null)
            {
                return NotFound();
            }
            return View(ghgType);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, GHGType ghgType)
        {
            if (id != ghgType.GHGTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _repo.UpdateGHGType(ghgType);
                return RedirectToAction(nameof(Index));
            }
            return View(ghgType);
        }

       
        public IActionResult Delete(int id)
        {
            var ghgType = _repo.GetGHGTypeById(id);
            if (ghgType == null)
            {
                return NotFound();
            }
            return View(ghgType);
        }

        // POST: GHGType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _repo.DeleteGHGType(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
