using KeyStore.Application.Common.Dto.Key;

namespace KeyStore.Application.Common.Dto.Key;

public record KeyListDto(IReadOnlyList<KeyInformationDto> keys);