using ConversaoAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ConversaoAPI.Controllers
{
    // Controller responsável por expor a API de conversão de moedas
    [ApiController]
    [Route("api/[controller]")]
    public class ConversaoController : ControllerBase
    {
        private readonly IConversaoService _service;

        public ConversaoController(IConversaoService service)
        {
            _service = service;
        }

        [HttpGet("converter")]
        public async Task<IActionResult> Converter(
            [FromQuery] string moedaOrigem, 
            [FromQuery] string moedaDestino, 
            [FromQuery] decimal valor)
        {
            try
            {
                var resultado = await _service.Converter(moedaOrigem, moedaDestino, valor);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = ex.Message
                });
            }
        }
    }
}
