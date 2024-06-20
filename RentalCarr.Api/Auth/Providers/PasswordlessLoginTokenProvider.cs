using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using KeyStore.Api.Auth.Options;

namespace KeyStore.Api.Auth.Providers;

public class PasswordlessLoginTokenProvider<TUser> : DataProtectorTokenProvider<TUser> where TUser : class   // token generation
{
    public PasswordlessLoginTokenProvider(IDataProtectionProvider dataProtectionProvider, IOptions<PasswordlessLoginTokenProviderOptions> options, ILogger<DataProtectorTokenProvider<TUser>> logger) : base(dataProtectionProvider,
        options,
        logger)
    {
    }
}
