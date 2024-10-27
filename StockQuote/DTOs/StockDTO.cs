namespace StockQuote.DTOs;

public record StockDTO(
    string Symbol,
    decimal CurrentPrice
);