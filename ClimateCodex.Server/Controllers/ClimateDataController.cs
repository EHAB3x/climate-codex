using Microsoft.AspNetCore.Mvc;
using ClimateCodex.Server.Data; 
using ClimateCodex.Server.Models;
using ClimateCodex.Server.Repository; 

namespace ClimateCodex.Server.Controllers
{
    public class ClimateDataController : Controller
    {
        private readonly IClimateDataRepo _climateDataRepo;

        public ClimateDataController(IClimateDataRepo climateDataRepo)
        {
            _climateDataRepo = climateDataRepo;
        }

       
        public IActionResult Index()
        {
            var climateDataList = _climateDataRepo.GetAllClimateData();
            return View(climateDataList);
        }

        
        public IActionResult Details(int id)
        {
            var climateData = _climateDataRepo.GetClimateDataById(id);
            if (climateData == null)
            {
                return NotFound();
            }
            return View(climateData);
        }

       
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ClimateData climateData)
        {
            if (ModelState.IsValid)
            {
                _climateDataRepo.AddClimateData(climateData);
                return RedirectToAction(nameof(Index));
            }
            return View(climateData);
        }

       
        public IActionResult Edit(int id)
        {
            var climateData = _climateDataRepo.GetClimateDataById(id);
            if (climateData == null)
            {
                return NotFound();
            }
            return View(climateData);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ClimateData climateData)
        {
            if (id != climateData.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _climateDataRepo.UpdateClimateData(climateData);
                return RedirectToAction(nameof(Index));
            }
            return View(climateData);
        }

       
        public IActionResult Delete(int id)
        {
            var climateData = _climateDataRepo.GetClimateDataById(id);
            if (climateData == null)
            {
                return NotFound();
            }
            return View(climateData);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _climateDataRepo.DeleteClimateData(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
