namespace KeyStore.Application.Common.Dto.Category;

public record UpdateKeyCategoryDto(string KeyCategoryId, string? Name, bool? Active);