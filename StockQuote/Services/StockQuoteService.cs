using StockQuote.Services.Interfaces;

namespace StockQuote.Services;

public class StockQuoteService : IStockQuoteService
{
    private const int FIVE_SECONDS_IN_MILLISECONDS = 5000;

    private readonly IStockService _stockService;
    private readonly IEmailService _emailService;


    public StockQuoteService(IStockService stockService, IEmailService emailService)
    {
        _stockService = stockService;
        _emailService = emailService;
    }

    public async Task TrackStock(string symbol, decimal buyPrice, decimal sellPrice)
    {
        while (true)
        {
            try
            {
                Console.WriteLine("Getting the stock price");
                var stock = await _stockService.GetStock(symbol);

                if (stock.CurrentPrice < buyPrice)
                    await SendBuyRecommendationEmail(symbol);

                else if (stock.CurrentPrice > sellPrice)
                    await SendSellRecommendationEmail(symbol);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error ocurred while processing: {ex.Message}");
            }

            await Task.Delay(FIVE_SECONDS_IN_MILLISECONDS);
        }
    }

    private async Task SendBuyRecommendationEmail(string symbol)
    {
        Console.WriteLine("Sending Email 'Recomendação de Compra'");
        var body = $@"
            <h1>Olá!</h1>
            <p>
                O ativo <strong>{symbol}</strong> está com uma excelente oportunidade de <strong>compra</strong>!
            </p>
        ";
        await _emailService.SendEmail(subject: "Recomendação de Compra", body);
    }

    private async Task SendSellRecommendationEmail(string symbol)
    {
        Console.WriteLine("Sending Email 'Recomendação de venda'");
        var body = $@"
            <h1>Olá!</h1>
            <p>
                O ativo <strong>{symbol}</strong> está com uma excelente oportunidade de <strong>venda</strong>!
            </p>
        ";

        await _emailService.SendEmail(subject: "Recomendação de venda", body);
    }
}
