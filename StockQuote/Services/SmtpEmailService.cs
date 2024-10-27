using System.Net;
using System.Net.Mail;

using Microsoft.Extensions.Options;

using StockQuote.Configuration;
using StockQuote.Services.Interfaces;

namespace StockQuote.Services;

public class SmtpEmailService : IEmailService
{
    private readonly EmailOptions _options;

    public SmtpEmailService(IOptions<EmailOptions> configuration)
    {
        _options = configuration.Value;
    }

    public async Task SendEmail(string subject, string body)
    {
        var smtpClient = new SmtpClient
        {
            Host = _options.Host,
            Port = _options.Port,
            Credentials = new NetworkCredential(_options.UserName, _options.Password),
            DeliveryMethod = SmtpDeliveryMethod.Network,
        };

        var mail = new MailMessage
        {
            From = new MailAddress(_options.FromEmail),
        };

        foreach (var recipientEmail in _options.Recipients)
        {
            mail.To.Add(new MailAddress(recipientEmail));
        };

        mail.Subject = subject;
        mail.Body = body;
        mail.IsBodyHtml = true;

        await smtpClient.SendMailAsync(mail);
    }
}
