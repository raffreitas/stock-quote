using StockQuote.DTOs;

namespace StockQuote.Services.Interfaces;

public interface IStockService
{
    Task<StockDTO> GetStock(string symbol);
}
