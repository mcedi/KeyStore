using KeyStore.Application.Common.Dto.Auth;

namespace KeyStore.Application.Common.Interfaces;

public interface IAuthService
{
    Task<BeginLoginResponseDto> BeginLoginAsync(string emailAddress);
    Task<CompleteLoginResponseDto> CompleteLoginAsync(string token);
}
