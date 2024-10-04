using ClimateCodex.Server.Repository;
using ClimateCodex.Server.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ClimateCodex.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly IRegionRepo _regionRepo;

        public RegionController(IRegionRepo regionRepo)
        {
            _regionRepo = regionRepo;
        }

        
        [HttpGet]
        public IActionResult GetAllRegions()
        {
            var regions = _regionRepo.GetAllRegions();
            return Ok(regions); 
        }

        
        [HttpGet("{id}")]
        public IActionResult GetRegionById(int id)
        {
            var region = _regionRepo.GetRegionById(id);
            if (region == null)
            {
                return NotFound(); 
            }
            return Ok(region); 
        }

        
        [HttpPost]
        public IActionResult Create([FromBody] Region region)
        {
            if (ModelState.IsValid)
            {
                _regionRepo.AddRegion(region);
                return CreatedAtAction(nameof(GetRegionById), new { id = region.RegionId }, region); 
            }
            return BadRequest(ModelState); 
        }

       
        [HttpPut("{id}")]
        public IActionResult Edit(int id, [FromBody] Region region)
        {
            if (id != region.RegionId)
            {
                return BadRequest(); 
            }

            if (ModelState.IsValid)
            {
                _regionRepo.UpdateRegion(region);
                return NoContent(); 
            }
            return BadRequest(ModelState); 
        }

        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var region = _regionRepo.GetRegionById(id);
            if (region == null)
            {
                return NotFound();
            }

            _regionRepo.DeleteRegion(id);
            return NoContent(); 
        }
    }
}
