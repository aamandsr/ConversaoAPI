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

        // Tenta obter a taxa de conversão direta. Se falhar, tenta via EUR
        public async Task<ConversaoResponseDTO> Converter(string moedaOrigem, string moedaDestino, decimal valor)
        {
            decimal taxaFinal;

            try
            {
                // tenta conversão direta
                var resposta = await _client.ObterTaxaAtual(moedaOrigem, moedaDestino);

                if (!resposta.Rates.ContainsKey(moedaDestino))
                    throw new Exception();

                taxaFinal = resposta.Rates[moedaDestino];
            }
            catch
            {
                try
                {
                    // fallback via EUR

                    if (moedaOrigem == "EUR")
                    {
                        // se a moeda de origem for EUR, basta obter a taxa para a moeda destino
                        var respostaDestino = await _client.ObterTaxaAtual("EUR", moedaDestino);
                        taxaFinal = respostaDestino.Rates[moedaDestino];
                    }
                    else if (moedaDestino == "EUR")
                    {
                        // se a moeda de destino for EUR, basta obter a taxa para a moeda origem e inverter
                        var respostaOrigem = await _client.ObterTaxaAtual(moedaOrigem, "EUR");
                        taxaFinal = respostaOrigem.Rates["EUR"];
                    }
                    else
                    {
                        // obtém taxas para ambas as moedas em relação ao EUR e calcula a taxa cruzada
                        var respostaBase = await _client.ObterTaxaAtual("EUR", moedaOrigem + "," + moedaDestino);

                        var taxaOrigem = respostaBase.Rates[moedaOrigem];
                        var taxaDestino = respostaBase.Rates[moedaDestino];

                        taxaFinal = taxaDestino / taxaOrigem;
                    }
                }
                catch
                {
                    // erro real (moeda inválida ou API falhou)
                    throw new Exception("Não foi possível realizar a conversão. Verifique as moedas informadas.");
                }
            }

            // calcula valor convertido
            var valorConvertido = valor * taxaFinal;

            return new ConversaoResponseDTO
            {
                MoedaOrigem = moedaOrigem,
                MoedaDestino = moedaDestino,
                Taxa = taxaFinal,
                ValorConvertido = valorConvertido
            };
        }
    }
}
