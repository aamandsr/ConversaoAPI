namespace ConversaoAPI.Models.External
{
    // Modelo para resposta da API Frankfurter
    // Usado para mapear os dados recebidos da API externa
    public class FrankfurterResponse
    {
        public string Base { get; set; }
        public string Date { get; set; }
        public Dictionary<string, decimal> Rates { get; set; }
    }
}
