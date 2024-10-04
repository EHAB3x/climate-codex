using ClimateCodex.Server.Repository;
using ClimateCodex.Server.Models; 
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ClimateCodex.Server.Controllers
{
    public class RegionController : Controller
    {
        private readonly IRegionRepo _regionRepo;

        public RegionController(IRegionRepo regionRepo)
        {
            _regionRepo = regionRepo;
        }

        
        public IActionResult Index()
        {
            var regions = _regionRepo.GetAllRegions();
            return View(regions); 
        }

        
        public IActionResult Details(int id)
        {
            var region = _regionRepo.GetRegionById(id);
            if (region == null)
            {
                return NotFound();
            }
            return View(region); 
        }

       
        public IActionResult Create()
        {
            return View(); 
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Region region)
        {
            if (ModelState.IsValid)
            {
                _regionRepo.AddRegion(region);
                return RedirectToAction(nameof(Index));
            }
            return View(region);
        }

        
        public IActionResult Edit(int id)
        {
            var region = _regionRepo.GetRegionById(id);
            if (region == null)
            {
                return NotFound();
            }
            return View(region);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Region region)
        {
            if (id != region.RegionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _regionRepo.UpdateRegion(region);
                return RedirectToAction(nameof(Index));
            }
            return View(region);
        }

       
        public IActionResult Delete(int id)
        {
            var region = _regionRepo.GetRegionById(id);
            if (region == null)
            {
                return NotFound();
            }
            return View(region);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _regionRepo.DeleteRegion(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
