using ConversaoAPI.Models.External;

namespace ConversaoAPI.Clients.Interfaces
{
    //Responsavel por definir os métodos obrigatorios de comunicação com a API Frankfurter
    public interface IFrankfurterClient
    {
        Task<FrankfurterResponse> ObterTaxaAtual(string moedaOrigem, string moedaDestino);
    }
}
