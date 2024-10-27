namespace StockQuote.Services.Interfaces;

public interface IEmailService
{
    Task SendEmail(string subject, string body);
}
