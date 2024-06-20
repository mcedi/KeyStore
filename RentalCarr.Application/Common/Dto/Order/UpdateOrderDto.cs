namespace KeyStore.Application.Common.Dto.Order;

public record UpdateOrderDto(string OrderId, IEnumerable<string?> Customer, IEnumerable<string?> Keys, double? TotalPrice, string? Status);