using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace ClimateCodex.Server.Controllers
{
    public class TestController : Controller
    {
        private readonly HttpClient _httpClient;

        public TestController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet("test-ch4-data")]
        public async Task<IActionResult> GetCh4Data(int year, int month)
        {
            // Call  Flask API
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
