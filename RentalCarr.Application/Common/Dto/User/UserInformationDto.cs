namespace KeyStore.Application.Common.Dto.User;

public record UserInformationDto(string? FirstName, string? LastName, string? Email, string? NormalizedEmail,
    string? UserName, string? NormalizedUserName, IEnumerable<string?> Keys, List<string> Roles);
