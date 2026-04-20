using ConversaoAPI.Models.DTOs;

namespace ConversaoAPI.Services.Interfaces
{
    // Responsável por definir a regra de conversão de moedas
    public interface IConversaoService
    {
        Task<ConversaoResponseDTO> Converter(string moedaOrigem, string moedaDestino, decimal valor);
    }
}
