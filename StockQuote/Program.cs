using Microsoft.Extensions.DependencyInjection;

using StockQuote.Extensions;
using StockQuote.Services.Interfaces;

if (Environment.GetCommandLineArgs().Length < 3)
{
    Console.WriteLine("The asset symbol, selling price and buying price must be provided.");
    Console.WriteLine("Press a key to exit");
    Console.Read();
    return;
}

var symbol = Environment.GetCommandLineArgs()[1];

if (!decimal.TryParse(Environment.GetCommandLineArgs()[2], out var sellPrice))
{
    Console.WriteLine($"Sell price must be a valid number");
    Console.WriteLine("Press a key to exit");
    Console.Read();
    return;
}

if (!decimal.TryParse(Environment.GetCommandLineArgs()[3], out var buyPrice))
{
    Console.WriteLine($"Buy price must be a valid number");
    Console.WriteLine("Press a key to exit");
    Console.Read();
    return;
}

using var serviceProvider = new ServiceCollection()
    .LoadConfiguration()
    .ConfigureServices()
    .BuildServiceProvider();

var stockQuoteService = serviceProvider.GetService<IStockQuoteService>();

await stockQuoteService.TrackStock(symbol, buyPrice, sellPrice);
