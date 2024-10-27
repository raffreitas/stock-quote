using Microsoft.Extensions.DependencyInjection;

using StockQuote.Services.Interfaces;
using StockQuote.Services;
using System.Text.Json;
using StockQuote.Configuration;

namespace StockQuote.Extensions;

public static class AppExtensions
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<IStockQuoteService, StockQuoteService>();
        services.AddScoped<IStockService, BrapiStockService>();
        services.AddScoped<IEmailService, SmtpEmailService>();

        return services;
    }

    public static IServiceCollection LoadConfiguration(this IServiceCollection services)
    {
        var settingsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "settings.json");

        var bytes = File.ReadAllBytes(settingsPath);

        var settings = JsonSerializer.Deserialize<Settings>(bytes);

        if (settings is null)
            throw new InvalidOperationException(nameof(LoadConfiguration));

        services
            .AddOptions<EmailOptions>()
            .Configure(options =>
            {
                options.Host = settings.EmailHost;
                options.Port = settings.EmailPort;
                options.UserName = settings.EmailUserName;
                options.Password = settings.EmailPassword;
                options.FromEmail = settings.EmailSender;
                options.Recipients = settings.EmailRecipients;
            })
            .ValidateDataAnnotations();

        services.AddOptions<StockApiOptions>()
            .Configure(options => options.ApiKey = settings.StockServiceApiKey)
            .ValidateDataAnnotations();

        return services;
    }
}
