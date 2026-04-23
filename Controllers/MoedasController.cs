using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConversaoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoedasController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public MoedasController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet]
        public async Task<IActionResult> ObterMoedas()
        {
            var response = await _httpClient.GetAsync("https://api.frankfurter.app/currencies");

            if (!response.IsSuccessStatusCode)
                return StatusCode((int)response.StatusCode, "Erro ao buscar moedas");

            var content = await response.Content.ReadAsStringAsync();

            return Content(content, "application/json");
        }
    }
}