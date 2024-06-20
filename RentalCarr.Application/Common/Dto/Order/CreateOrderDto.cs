namespace KeyStore.Application.Common.Dto.Order;

public record CreateOrderDto(string CustomerId, List<string> KeyIds);
