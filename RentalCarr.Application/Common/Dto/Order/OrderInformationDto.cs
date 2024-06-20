using KeyStore.Application.Common.Dto.Order;

namespace KeyStore.Application.Common.Dto.Order;

public record OrderInformationDto(long OrderCode, string? Customer, double TotalPrice, string Status,
    OrderInformationDto OrderInfo)
{
    internal OrderInformationDto AddOrderInfo(OrderInformationDto orderInformationDto)
    {
        return this with { OrderInfo = orderInformationDto };
    }
}
