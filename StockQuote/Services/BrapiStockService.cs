using System.Text.Json;

using Microsoft.Extensions.Options;

using StockQuote.Configuration;
using StockQuote.DTOs;
using StockQuote.Services.Interfaces;

namespace StockQuote.Services;

public class BrapiStockService : IStockService
{
    private const string BRAAPI_BASE_URL = "https://brapi.dev/api/";

    private readonly HttpClient _httpClient = new();

    private readonly StockApiOptions _options;

    public BrapiStockService(IOptions<StockApiOptions> options)
    {
        _options = options.Value;
        _httpClient.BaseAddress = new Uri(BRAAPI_BASE_URL);
    }

    public async Task<StockDTO> GetStock(string symbol)
    {
        var response = await _httpClient.GetAsync($"quote/{symbol}?token={_options.ApiKey}");

        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();

        var brapiStock = JsonSerializer.Deserialize<BrapiStockDTO>(content);

        var braapiResult = brapiStock.Results.First();

        return new StockDTO(braapiResult.Symbol, braapiResult.RegularMarketPrice);
    }
}


