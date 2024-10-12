using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace ClimateCodex.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MlDataController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public MlDataController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet("{year}/{month}")]
        public async Task<IActionResult> GetCh4Data(int year, int month)
        {
            string url = $"http://127.0.0.1:5000/ch4-data?year={year}&month={month}"; // Flask API URL
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
