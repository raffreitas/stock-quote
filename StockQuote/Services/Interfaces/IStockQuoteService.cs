namespace StockQuote.Services.Interfaces;

public interface IStockQuoteService
{
    Task TrackStock(string symbol, decimal buyPrice, decimal sellPrice);
}
