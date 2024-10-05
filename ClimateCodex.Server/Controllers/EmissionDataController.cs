using Microsoft.AspNetCore.Mvc;
using ClimateCodex.Server.Models;
using ClimateCodex.Server.Repository;

namespace ClimateCodex.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")] 
    public class EmissionDataController : ControllerBase
    {
        private readonly IEmissionDataRepo _repo;

        public EmissionDataController(IEmissionDataRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var emissions = _repo.GetAllEmissionData();
            return Ok(emissions); 
        }

        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {
            var emission = _repo.GetEmissionDataById(id);
            if (emission == null)
            {
                return NotFound(); 
            }
            return Ok(emission); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromBody] EmissionData emissionData)
        {
            if (ModelState.IsValid)
            {
                _repo.AddEmissionData(emissionData);
                _repo.SaveChanges();
                return CreatedAtAction(nameof(Details), new { id = emissionData.EmissionDataId }, emissionData); 
            }
            return BadRequest(ModelState); 
        }

        [HttpPut("{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [FromBody] EmissionData emissionData)
        {
            if (id != emissionData.EmissionDataId)
            {
                return BadRequest(); 
            }

            if (ModelState.IsValid)
            {
                _repo.UpdateEmissionData(emissionData);
                _repo.SaveChanges();
                return NoContent(); 
            }
            return BadRequest(ModelState); 
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var emission = _repo.GetEmissionDataById(id);
            if (emission == null)
            {
                return NotFound(); 
            }
            return Ok(emission); 
        }

        // DELETE confirmed
        [HttpPost("{id}/delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _repo.DeleteEmissionData(id);
            _repo.SaveChanges();
            return NoContent(); 
        }
    }
}
