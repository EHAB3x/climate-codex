using Microsoft.AspNetCore.Mvc;
using ClimateCodex.Server.Models;
using ClimateCodex.Server.Repository;

namespace ClimateCodex.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GHGTypeController : ControllerBase 
    {
        private readonly IGHGTypeRepo _repo;

        public GHGTypeController(IGHGTypeRepo repo)
        {
            _repo = repo;
        }

        
        [HttpGet]
        public IActionResult GetAllGHGTypes()
        {
            var ghgTypes = _repo.GetAllGHGTypes();
            return Ok(ghgTypes); 
        }

        
        [HttpGet("{id}")]
        public IActionResult GetGHGTypeById(int id)
        {
            var ghgType = _repo.GetGHGTypeById(id);
            if (ghgType == null)
            {
                return NotFound(); 
            }
            return Ok(ghgType); 
        }

        
        [HttpPost]
        public IActionResult CreateGHGType([FromBody] GHGType ghgType)
        {
            if (ModelState.IsValid)
            {
                _repo.AddGHGType(ghgType);
                return CreatedAtAction(nameof(GetGHGTypeById), new { id = ghgType.GHGTypeId }, ghgType); 
            }
            return BadRequest(ModelState); 
        }

        
        [HttpPut("{id}")]
        public IActionResult EditGHGType(int id, [FromBody] GHGType ghgType)
        {
            if (id != ghgType.GHGTypeId)
            {
                return BadRequest(); 
            }

            if (ModelState.IsValid)
            {
                _repo.UpdateGHGType(ghgType);
                return NoContent(); 
            }
            return BadRequest(ModelState); 
        }

       
        [HttpDelete("{id}")]
        public IActionResult DeleteGHGType(int id)
        {
            var ghgType = _repo.GetGHGTypeById(id);
            if (ghgType == null)
            {
                return NotFound(); 
            }
            _repo.DeleteGHGType(id);
            return NoContent(); 
        }

        
        [HttpGet("faq")]
        public IActionResult GetGHGFAQ()
        {
            var faq = new[]
            {
                new
                {
                    GasName = "Methane (CH₄)",
                    Questions = new[]
                    {
                        new { Question = "What is the molecular formula of Methane?", Answer = "CH₄" },
                        new { Question = "What is the molecular weight of Methane?", Answer = "16.04 g/mol" },
                        new { Question = "What are the sources of Methane?",
                            Answer = "Natural Sources: Wetlands, Termites, Oceans. Anthropogenic Sources: Fossil fuels, Agriculture, Landfills, Wastewater treatment." },
                        new { Question = "What are the environmental impacts of Methane?",
                            Answer = "Methane is a potent greenhouse gas, with a global warming potential over 25 times greater than CO₂ over a 100-year period. It also contributes to the formation of ground-level ozone." },
                        new { Question = "What are the uses of Methane?",
                            Answer = "Methane is used for energy production, as a chemical feedstock, and in biofuels. It is a key component in the production of hydrogen, methanol, and ammonia." },
                        new { Question = "What are the mitigation strategies for Methane emissions?",
                            Answer = "Reduction in emissions through improved management practices in agriculture and waste, capture technologies for methane in landfills, and transitioning to renewable energy sources." }
                    }
                },
                new
                {
                    GasName = "Carbon Dioxide (CO₂)",
                    Questions = new[]
                    {
                        new { Question = "What is Carbon Dioxide (CO₂)?", Answer = "CO₂ is a colorless, odorless gas naturally present in the Earth’s atmosphere. It is a vital component of the carbon cycle." },
                        new { Question = "What is the role of CO₂ in the environment?",
                            Answer = "CO₂ plays a key role in photosynthesis and contributes to the greenhouse effect, helping to trap heat and regulate the Earth’s temperature." },
                        new { Question = "What are the sources of CO₂ emissions?",
                            Answer = "Natural sources: Respiration, volcanic eruptions, ocean release. Human activities: Fossil fuel burning, deforestation, industrial processes." },
                        new { Question = "What is the impact of increased CO₂ levels?",
                            Answer = "Increased CO₂ levels contribute to climate change, ocean acidification, and poor air quality. These effects result in rising sea levels, extreme weather, and harm to marine life." },
                        new { Question = "What are ways to reduce CO₂ emissions?",
                            Answer = "Reduction strategies include transitioning to renewable energy, enhancing energy efficiency, sustainable transportation, afforestation, and carbon capture technologies." }
                    }
                }
            };

            return Ok(faq); 
        }
    }
}
