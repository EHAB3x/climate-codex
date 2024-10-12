using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace ClimateCodex.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        // Inject HttpClient via constructor dependency injection
        public TestController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        // API Endpoint to get CH₄ data from Flask
        [HttpGet("test-ch4-data")]
        public async Task<IActionResult> GetCh4Data(int year, int month)
        {
            // Call the Flask API endpoint
            var response = await _httpClient.GetAsync($"http://localhost:5000/ch4-data?year={year}&month={month}");

            if (response.IsSuccessStatusCode)
            {
                var ch4Data = await response.Content.ReadAsStringAsync();
                return Content(ch4Data, "application/json");
            }

            return StatusCode((int)response.StatusCode);
        }
    }
}
