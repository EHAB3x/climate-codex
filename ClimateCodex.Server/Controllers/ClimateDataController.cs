using Microsoft.AspNetCore.Mvc;
using ClimateCodex.Server.Repository;
using ClimateCodex.Server.Models;

namespace ClimateCodex.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")] 
    public class ClimateDataController : ControllerBase
    {
        private readonly IClimateDataRepo _climateDataRepo;

        public ClimateDataController(IClimateDataRepo climateDataRepo)
        {
            _climateDataRepo = climateDataRepo;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var climateDataList = _climateDataRepo.GetAllClimateData();
            return Ok(climateDataList); 
        }

        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {
            var climateData = _climateDataRepo.GetClimateDataById(id);
            if (climateData == null)
            {
                return NotFound();
            }
            return Ok(climateData); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromBody] ClimateData climateData)
        {
            if (ModelState.IsValid)
            {
                _climateDataRepo.AddClimateData(climateData);
                return CreatedAtAction(nameof(Details), new { id = climateData.Id }, climateData); 
            }
            return BadRequest(ModelState); 
        }

        [HttpPut("{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [FromBody] ClimateData climateData)
        {
            if (id != climateData.Id)
            {
                return BadRequest(); 
            }

            if (ModelState.IsValid)
            {
                _climateDataRepo.UpdateClimateData(climateData);
                return NoContent(); 
            }
            return BadRequest(ModelState); 
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var climateData = _climateDataRepo.GetClimateDataById(id);
            if (climateData == null)
            {
                return NotFound(); 
            }
            _climateDataRepo.DeleteClimateData(id);
            return NoContent(); 
        }
    }
}
