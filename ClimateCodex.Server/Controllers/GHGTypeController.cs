using ClimateCodex.Server.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ClimateCodex.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GHGTypeController : ControllerBase
    {
        private readonly List<GHGType> ghgTypes = new List<GHGType>
        {
            new GHGType
            {
                GHGTypeId = 1,
                GasName = "Methane (CH₄)",
                Description = @"
                    <b>What is the molecular formula of Methane?</b> CH₄<br />
                    <b>What is the molecular weight of Methane?</b> 16.04 g/mol<br />
                    <b>What are the sources of Methane?</b>
                    Natural Sources: Wetlands, Termites, Oceans. 
                    Anthropogenic Sources: Fossil fuels, Agriculture, Landfills, Wastewater treatment.<br />
                    <b>What are the environmental impacts of Methane?</b>
                    Methane is a potent greenhouse gas, with a global warming potential over 25 times greater than CO₂ over a 100-year period. 
                    It also contributes to the formation of ground-level ozone.<br />
                    <b>What are the uses of Methane?</b>
                    Methane is used for energy production, as a chemical feedstock, and in biofuels. 
                    It is a key component in the production of hydrogen, methanol, and ammonia.<br />
                    <b>What are the mitigation strategies for Methane emissions?</b>
                    Reduction in emissions through improved management practices in agriculture and waste, 
                    capture technologies for methane in landfills, and transitioning to renewable energy sources."
            },
            new GHGType
            {
                GHGTypeId = 2,
                GasName = "Carbon Dioxide (CO₂)",
                Description = @"
                    <b>What is Carbon Dioxide (CO₂)?</b> CO₂ is a colorless, odorless gas naturally present in the Earth’s atmosphere. 
                    It is a vital component of the carbon cycle.<br />
                    <b>What is the role of CO₂ in the environment?</b>
                    CO₂ plays a key role in photosynthesis and contributes to the greenhouse effect, helping to trap heat and regulate the Earth’s temperature.<br />
                    <b>What are the sources of CO₂ emissions?</b>
                    Natural sources: Respiration, volcanic eruptions, ocean release. 
                    Human activities: Fossil fuel burning, deforestation, industrial processes.<br />
                    <b>What is the impact of increased CO₂ levels?</b>
                    Increased CO₂ levels contribute to climate change, ocean acidification, and poor air quality. 
                    These effects result in rising sea levels, extreme weather, and harm to marine life.<br />
                    <b>What are ways to reduce CO₂ emissions?</b>
                    Reduction strategies include transitioning to renewable energy, enhancing energy efficiency, sustainable transportation, 
                    afforestation, and carbon capture technologies."
            }
        };

        private readonly List<dynamic> faqList = new List<dynamic>
        {
            new
            {
                GHGTypeId = 1,
                GasName = "Methane (CH₄)",
                Questions = new[]
                {
                    new { Question = "What is the molecular formula of Methane?", Answer = "CH₄" },
                    new { Question = "What is the molecular weight of Methane?", Answer = "16.04 g/mol" },
                    new { Question = "What are the sources of Methane?", Answer = "Natural Sources: Wetlands, Termites, Oceans. Anthropogenic Sources: Fossil fuels, Agriculture, Landfills, Wastewater treatment." },
                    new { Question = "What are the environmental impacts of Methane?", Answer = "Methane is a potent greenhouse gas, with a global warming potential over 25 times greater than CO₂ over a 100-year period. It also contributes to the formation of ground-level ozone." },
                    new { Question = "What are the uses of Methane?", Answer = "Methane is used for energy production, as a chemical feedstock, and in biofuels. It is a key component in the production of hydrogen, methanol, and ammonia." },
                    new { Question = "What are the mitigation strategies for Methane emissions?", Answer = "Reduction in emissions through improved management practices in agriculture and waste, capture technologies for methane in landfills, and transitioning to renewable energy sources." }
                }
            },
            new
            {
                GHGTypeId = 2,
                GasName = "Carbon Dioxide (CO₂)",
                Questions = new[]
                {
                    new { Question = "What is Carbon Dioxide (CO₂)?", Answer = "CO₂ is a colorless, odorless gas naturally present in the Earth’s atmosphere. It is a vital component of the carbon cycle." },
                    new { Question = "What is the role of CO₂ in the environment?", Answer = "CO₂ plays a key role in photosynthesis and contributes to the greenhouse effect, helping to trap heat and regulate the Earth’s temperature." },
                    new { Question = "What are the sources of CO₂ emissions?", Answer = "Natural sources: Respiration, volcanic eruptions, ocean release. Human activities: Fossil fuel burning, deforestation, industrial processes." },
                    new { Question = "What is the impact of increased CO₂ levels?", Answer = "Increased CO₂ levels contribute to climate change, ocean acidification, and poor air quality. These effects result in rising sea levels, extreme weather, and harm to marine life." },
                    new { Question = "What are ways to reduce CO₂ emissions?", Answer = "Reduction strategies include transitioning to renewable energy, enhancing energy efficiency, sustainable transportation, afforestation, and carbon capture technologies." }
                }
            }
        };

        // This method retrieves all GHG types
        [HttpGet]
        public IActionResult GetAllGHGTypes()
        {
            return Ok(ghgTypes);
        }

        // Get a specific FAQ by GHGTypeId
        [HttpGet("faq/{id:int}")]
        public IActionResult GetGHGFAQById(int id)
        {
            var faq = faqList.FirstOrDefault(f => f.GHGTypeId == id);
            if (faq == null)
            {
                return NotFound(new { message = $"FAQ with ID {id} not found." });
            }
            return Ok(faq);
        }
    }
}
