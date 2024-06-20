namespace KeyStore.Application.Common.Dto.Key;

public record KeyInformationDto(
    string Name,
    string Img,
    string Description,
    string KeyVendor,
    string KeyCategory,
    string KeyType,
    string Owner,
    bool IsSold,
    bool IsBought,
    double Price,
    DateTime StartDate,
    DateTime EndDate
);
