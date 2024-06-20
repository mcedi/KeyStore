namespace KeyStore.Application.Common.Dto.Key;

public record CreateKeyDto(
    string Name,
    string Img,
    string Description,
    string KeyVendorId,
    string KeyCategoryId,
    string KeyTypeId,
    string OwnerId,
    bool IsSold,
    double Price,
    DateTime StartDate,
    DateTime EndDate
);