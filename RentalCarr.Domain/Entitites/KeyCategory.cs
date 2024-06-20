using KeyStore.Domain.Common;
using MongoDB.Entities;
using KeyStore.Domain.Common;

namespace KeyStore.Domain.Entities;

[Collection("keyCategory")]
public class KeyCategory : AuditableEntity
{
    [Field("name")]
    public string Name
    {
        get;
        set;
    }

    public KeyCategory()
    {

    }

}