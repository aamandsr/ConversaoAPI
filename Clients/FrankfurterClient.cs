using ConversaoAPI.Clients.Interfaces;
using ConversaoAPI.Models.External;

namespace ConversaoAPI.Clients
{
    //Classe responsável por consumir a API externa Frankfurter
    public class FrankfurterClient : IFrankfurterClient
    {
        private readonly HttpClient _httpClient;

        public FrankfurterClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<FrankfurterResponse> ObterTaxaAtual(string moedaOrigem, string moedaDestino)
        {
            var url = $"latest?from={moedaOrigem}&to={moedaDestino}";

            var resposta = await _httpClient.GetFromJsonAsync<FrankfurterResponse>(url);
            
            return resposta;
        }
    }
}
