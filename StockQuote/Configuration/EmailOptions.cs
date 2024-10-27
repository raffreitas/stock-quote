using System.ComponentModel.DataAnnotations;

namespace StockQuote.Configuration;

public class EmailOptions
{
    [Required]
    public string Host { get; set; } = string.Empty;

    [Required]
    public int Port { get; set; }

    [Required]
    public string UserName { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; } = string.Empty;

    [Required]
    public string FromEmail { get; set; } = string.Empty;

    [Required]
    [MinLength(1)]
    public IList<string> Recipients { get; set; } = [];
}
