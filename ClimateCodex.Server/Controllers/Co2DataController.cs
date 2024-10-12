using Microsoft.AspNetCore.Mvc;

namespace ClimateCodex.Server.Controllers
{
    
        [ApiController]
        [Route("api/[controller]")]
        public class Co2DataController : ControllerBase
        {
            private readonly HttpClient _httpClient;

            public Co2DataController(HttpClient httpClient)
            {
                _httpClient = httpClient;
            }

            [HttpGet("{year}/{month}")]
            public async Task<IActionResult> GetCo2Data(int year, int month)
            {
                string url = $"http://127.0.0.1:5000/co2-data?year={year}&month={month}"; // Update with your Flask API URL
                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    return Ok(data);
                }
                return NotFound(new { error = "Data not available for the specified date" });
            }
        }
    }

