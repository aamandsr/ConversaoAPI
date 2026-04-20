using ConversaoAPI.Services.Interfaces;
using ConversaoAPI.Models.DTOs;
using ConversaoAPI.Clients.Interfaces;

namespace ConversaoAPI.Services
{
    // Responsável por toda regra de conversão de moedas
    public class ConversaoService : IConversaoService
    {
        private readonly IFrankfurterClient _client;

        public ConversaoService(IFrankfurterClient client)
        {
            _client = client;
        }

        public async Task<ConversaoResponseDTO> Converter(string moedaOrigem, string moedaDestino, decimal valor)
        {
            var resposta = await _client.ObterTaxaAtual(moedaOrigem, moedaDestino);
            var taxa = resposta.Rates[moedaDestino];
            var valorConvertido = valor * taxa;
            return new ConversaoResponseDTO
            {
                MoedaOrigem = moedaOrigem,
                MoedaDestino = moedaDestino,
                Taxa = taxa,
                ValorConvertido = valorConvertido
            };
        }
    }
}
