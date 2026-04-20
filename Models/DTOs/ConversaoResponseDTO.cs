namespace ConversaoAPI.Models.DTOs
{
    // DTO para resposta da conversão de moedas
    // Contém as informações sobre a moeda de origem, moeda de destino, taxa de conversão e valor convertido
    // Esse DTO é retornado pela API para o cliente
    public class ConversaoResponseDTO
    {
        public string MoedaOrigem { get; set; }
        public string MoedaDestino { get; set; }
        public decimal Taxa { get; set; }
        public decimal ValorConvertido { get; set; }
    }
}
