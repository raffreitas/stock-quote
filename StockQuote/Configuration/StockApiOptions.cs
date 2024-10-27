using System.ComponentModel.DataAnnotations;

namespace StockQuote.Configuration;

public class StockApiOptions
{
    [Required]
    public string ApiKey { get; set; } = string.Empty;
}
