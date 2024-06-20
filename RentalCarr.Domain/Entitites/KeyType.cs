using KeyStore.Domain.Common;
using MongoDB.Entities;


namespace KeyStore.Domain.Entities;

[Collection("keyType")]
public class KeyType : AuditableEntity
{
    [Field("name")]
    public string Name
    {
        get;
        set;
    }

    public KeyType()
    {

    }

}
