namespace StockQuote;

public class Settings
{
    public string EmailHost { get; set; } = string.Empty;

    public int EmailPort { get; set; }

    public string EmailUserName { get; set; } = string.Empty;

    public string EmailPassword { get; set; } = string.Empty;

    public IList<string> EmailRecipients { get; set; } = [];

    public string EmailSender { get; set; } = string.Empty;

    public string StockServiceApiKey { get; set; } = string.Empty;
}
