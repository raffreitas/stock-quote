using System.Text.Json.Serialization;

namespace StockQuote.DTOs;

public class BrapiStockDTO
{
    [JsonPropertyName("results")]
    public IEnumerable<BraapiStockDTOResult> Results { get; set; }

    public class BraapiStockDTOResult
    {
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;

        [JsonPropertyName("regularMarketPrice")]
        public decimal RegularMarketPrice { get; set; }
    }
}