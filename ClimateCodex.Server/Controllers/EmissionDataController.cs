using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ClimateCodex.Server.Models;
using ClimateCodex.Server.Data;
using ClimateCodex.Server.Repository;

namespace ClimateCodex.Server.Controllers
{
    public class EmissionDataController : Controller
    {
        private readonly IEmissionDataRepo _repo;

        public EmissionDataController(IEmissionDataRepo repo)
        {
            _repo = repo;
        }

        
        public IActionResult Index()
        {
            var emissions = _repo.GetAllEmissionData();
            return View(emissions);
        }

        
        public IActionResult Details(int id)
        {
            var emission = _repo.GetEmissionDataById(id);
            if (emission == null)
            {
                return NotFound();
            }
            return View(emission);
        }

        
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EmissionData emissionData)
        {
            if (ModelState.IsValid)
            {
                _repo.AddEmissionData(emissionData);
                _repo.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(emissionData);
        }

        
        public IActionResult Edit(int id)
        {
            var emission = _repo.GetEmissionDataById(id);
            if (emission == null)
            {
                return NotFound();
            }
            return View(emission);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, EmissionData emissionData)
        {
            if (id != emissionData.EmissionDataId)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _repo.UpdateEmissionData(emissionData);
                _repo.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(emissionData);
        }

       
        public IActionResult Delete(int id)
        {
            var emission = _repo.GetEmissionDataById(id);
            if (emission == null)
            {
                return NotFound();
            }
            return View(emission);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _repo.DeleteEmissionData(id);
            _repo.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
