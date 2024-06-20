using Microsoft.AspNetCore.Identity;

namespace KeyStore.Api.Auth.Options;

public class PasswordlessLoginTokenProviderOptions : DataProtectionTokenProviderOptions  // konstruktor
{
    public PasswordlessLoginTokenProviderOptions()
    {
        Name = "PasswordlessLoginTokenProvider";
        TokenLifespan = TimeSpan.FromMinutes(15);
    }
}
