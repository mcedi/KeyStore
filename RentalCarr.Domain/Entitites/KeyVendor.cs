using KeyStore.Domain.Common;
using MongoDB.Entities;
using KeyStore.Domain.Common;

namespace KeyStore.Domain.Entities;

[Collection("keyVendors")]
public class KeyVendor : AuditableEntity
{
    [Field("name")]
    public string Name
    {
        get;
        set;
    }

    [Field("keyType")]
    public string Type
    {
        get;
        set;
    }

    public KeyVendor()
    {

    }
}